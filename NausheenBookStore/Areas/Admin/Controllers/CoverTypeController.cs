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

        //API Calls here
        [HttpGet]

        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.CoverType.GetAll();
            return Json(new { data = allObj });
        }
    }
}
