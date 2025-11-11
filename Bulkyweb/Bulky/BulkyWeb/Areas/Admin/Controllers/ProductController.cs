using BulkyWeb.DataAccess.Repository.IRepository;
using BulkyWeb.Models;
using BulkyWeb.Models.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitofwork Db , IWebHostEnvironment webHostEnvironment)
        {
            _unitofwork = Db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> products = _unitofwork.product.GetAll(includePropeties: "catogery").ToList();
            return View(products);
        }
        public IActionResult Upsert(int? Id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitofwork.category.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                product = new Product()
            };
            if(Id == null || Id==0)
            {
                return View(productVM);
            }
            else
            {
                productVM.product = _unitofwork.product.Get(u=>u.Id == Id);
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM obj , IFormFile? file)
        {
            if (obj.product.Title != null && obj.product.Title.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test Is Invalid Category Name");
            }
            if (ModelState.IsValid)
            {
                string wweRootPath = _webHostEnvironment.WebRootPath;
                if(file !=null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wweRootPath, @"Images\Product");
                    if (!string.IsNullOrEmpty(obj.product.ImageURL))
                    {
                        var oldImage = Path.Combine(wweRootPath,obj.product.ImageURL.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImage))
                        {
                            System.IO.File.Delete(oldImage);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);    
                    }
                    obj.product.ImageURL = @"\Images\Product\" + fileName;
                }
                if (obj.product.Id == 0)
                {
                    _unitofwork.product.Add(obj.product);
                    TempData["Successproduct"] = "Product Created SuccessFully";
                }
                else
                {
                    _unitofwork.product.Update(obj.product);
                    TempData["Successproduct"] = "Product Update SuccessFully";
                }
                _unitofwork.Save();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                obj.CategoryList = _unitofwork.category.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(obj);
            }
        }
        //public IActionResult Delete(int? Id)
        //{
        //    if (Id == null && Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    //Catogery? categoryFromDb = _dbContext.catogeries.Find(Id);
        //    Product? productFromDb = _unitofwork.product.Get(u => u.Id == Id);
        //    if (productFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productFromDb);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int? Id)
        //{
        //    if (Id == null && Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Product? productFromDb = _unitofwork.product.Get(u => u.Id == Id);
        //    if (productFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitofwork.product.Remove(productFromDb);
        //    TempData["Successproduct"] = "Product Deleted SuccessFully";
        //    _unitofwork.Save();
        //    return RedirectToAction("Index", "Product");
        //}
        #region API-CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = _unitofwork.product.GetAll(includePropeties: "catogery").ToList();
            return Json(new { data = products });
        }
        [HttpDelete]
        public IActionResult Delete(int? Id)
        {
            var productToBeDeleted = _unitofwork.product.Get(u => u.Id == Id);
            if(productToBeDeleted == null)
            {
                return Json(new {success = false , message = "Error While Deleting"});
            }
            var oldImage = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageURL.TrimStart('\\'));
            if (System.IO.File.Exists(oldImage))
            {
                System.IO.File.Delete(oldImage);
            }
            _unitofwork.product.Remove(productToBeDeleted);
            _unitofwork.Save();
            return Json(new { success = true, message = "Product Deleted Successfully" });
        }
        #endregion
    }
}
