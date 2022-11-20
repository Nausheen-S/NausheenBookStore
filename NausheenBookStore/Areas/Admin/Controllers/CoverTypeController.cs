using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NausheenBooks.DataAccess.Repository.IRepository;
using NausheenBookStore.DataAccess.Data;//add using statement
using NausheenBooks.Models; //added for upsert

namespace NausheenBookStore.Areas.Admin.Controllers
{
    //add area
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        //added unit of work
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        //add upsert func
        public IActionResult Upsert(int? id)
        {
            CoverType covertype = new CoverType();
            if (id == null)
            {
                //create
                return View(covertype);
            }
            //for edit
            covertype = _unitOfWork.CoverType.Get(id.GetValueOrDefault());
            if (covertype == null)
            {
                return NotFound();
            }
            return View(covertype); //note the argument is added
        }

        //http post here
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(CoverType covertype)
        {
            if (ModelState.IsValid)
            {
                if (covertype.CoverTypeId == 0)
                {
                    _unitOfWork.CoverType.Add(covertype);
                }
                else
                {
                    _unitOfWork.CoverType.Update(covertype);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(covertype);
        }



        //API Calls here
        [HttpGet]

        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.CoverType.GetAll();
            return Json(new { data = allObj });
        }

        //delete api call
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.CoverType.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _unitOfWork.CoverType.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
