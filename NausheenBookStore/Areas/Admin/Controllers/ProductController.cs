using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NausheenBooks.DataAccess.Repository.IRepository;
using NausheenBookStore.DataAccess.Data;//add using statement
using NausheenBooks.Models; //added for upsert
using Microsoft.AspNetCore.Hosting; //added new
using NausheenBooks.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NausheenBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        //added unit of work
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment; //to add images to server in wwwroot

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(id => new SelectListItem
                {
                    Text = id.CategoryName,
                    Value = id.CategoryId.ToString()
                }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(id => new SelectListItem
                {
                    Text = id.CoverTypeName,
                    Value = id.CoverTypeId.ToString()
                }),

            };
            if (id == null)
            {
                //create
                return View(productVM);
            }
            //for edit
            productVM.Product = _unitOfWork.Product.Get(id.GetValueOrDefault());
            if (productVM.Product == null)
            {
                return NotFound();
            }
            return View(productVM); //note the argument is added
        }


        //http post here
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                {
                    _unitOfWork.Product.Add(product);
                }
                else
                {
                    _unitOfWork.Product.Update(product);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        //API Calls here
        [HttpGet]

        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Product.GetAll(includeProperties:"Category, CoverType");
            return Json(new { data = allObj });
        }

        //delete api call
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Product.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _unitOfWork.Product.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
