using Microsoft.AspNetCore.Mvc;
using BulkyWeb.Models;
using Bulky.DataAccess.Data;
using BulkyWeb.DataAccess.Repository.IRepository;
using BulkyWeb.Utility;
using Microsoft.AspNetCore.Authorization;
namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Roleuser_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitofwork _unitofwork;
        public CategoryController(IUnitofwork DB)
        {
            _unitofwork = DB;
        }
        public IActionResult Index()
        {
           // var ctaegoryList = _dbContext.catogeries.ToList();
            List<Catogery> categoryList = _unitofwork.category.GetAll().ToList();
            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catogery obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cannot Match Excetly");
            }
            if(obj.Name!=null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test Is Invalid Category Name");
            }
            if (ModelState.IsValid)
            {
                _unitofwork.category.Add(obj);
                TempData["Success"] = "Category Created SuccessFully";
                _unitofwork.Save();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null && Id == 0)
            {
                return NotFound(); 
            }
            //Catogery? categoryFromDb = _dbContext.catogeries.Find(Id);
            Catogery? categoryFromDb = _unitofwork.category.Get(u=>u.Id==Id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Catogery obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cannot Match Excetly");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test Is Invalid Category Name");
            }
            if (ModelState.IsValid)
            {
                _unitofwork.category.Update(obj);
                TempData["Success"] = "Category Updated SuccessFully";
                _unitofwork.Save();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null && Id == 0)
            {
                return NotFound();
            }
            //Catogery? categoryFromDb = _dbContext.catogeries.Find(Id);
            Catogery? categoryFromDb = _unitofwork.category.Get(u => u.Id == Id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            if (Id == null && Id == 0)
            {
                return NotFound();
            }
            Catogery? categoryFromDb = _unitofwork.category.Get(u => u.Id == Id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _unitofwork.category.Remove(categoryFromDb);
            TempData["Success"] = "Category Deleted SuccessFully";
            _unitofwork.Save();
            return RedirectToAction("Index", "Category");
        }
    }
}
