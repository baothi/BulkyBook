using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
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

        //public async Task<IActionResult> Index(int productPage = 1)
        //{
        //    CategoryVM categoryVM = new CategoryVM()
        //    {
        //        Categories = await _unitOfWork.Category.GetAllAsync()
        //    };

        //    var count = categoryVM.Categories.Count();
        //    categoryVM.Categories = categoryVM.Categories.OrderBy(p => p.Name)
        //        .Skip((productPage - 1) * 2).Take(2).ToList();

        //    categoryVM.PagingInfo = new PagingInfo
        //    {
        //        CurrentPage = productPage,
        //        ItemsPerPage = 2,
        //        TotalItem = count,
        //        urlParam = "/Admin/Category/Index?productPage=:"
        //    };

        //    return View(categoryVM);
        //}

        //public async Task<IActionResult> Upsert(int? id)
        //{
        //    Category category = new Category();
        //    if (id == null)
        //    {
        //        //this is for create
        //        return View(category);
        //    }
        //    //this is for edit
        //    category = await _unitOfWork.Category.GetAsync(id.GetValueOrDefault());
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);

        //}

        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                //this is for create
                return View(category);
            }
            //this is for edit
            category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }
            return View(category);


            return View();
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }


        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var objFromDb = await _unitOfWork.Category.GetAsync(id);
        //    if (objFromDb == null)
        //    {
        //        TempData["Error"] = "Error deleting Category";
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }

        //    await _unitOfWork.Category.RemoveAsync(objFromDb);
        //    _unitOfWork.Save();

        //    TempData["Success"] = "Category successfully deleted";
        //    return Json(new { success = true, message = "Delete Successful" });

        //}

        #endregion
    }
}
