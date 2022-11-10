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
    //add are
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
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
            Category category = new Category();
            if(id == null)
            {
                //create
                return View(category);
            }
            //for edit
            category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if(category == null)
            {
                return NotFound();
            }
            return View(); //note the argument is added
        }

        //http post here
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Category category)
        {
            if(ModelState.IsValid)
            {
                if(category.CategoryId == 0)
                {
                    _unitOfWork.Category.Add(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        //API Calls here
        [HttpGet]

        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }

        //delete api call
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
