using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class editModel : PageModel
    {
        private readonly ApplicationDBContext _Db;
        public Category category { get; set; }  
        public editModel(ApplicationDBContext db)
        {
            _Db = db;
        }
        public void OnGet(int? Id)
        {
            if (Id !=null && Id != 0)
            {
                category = _Db.categories.Find(Id);
            }
        }
        public IActionResult OnPost()
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cannot Match Excetly");
            }
            if (category.Name != null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test Is Invalid Category Name");
            }
            if (ModelState.IsValid)
            {
                _Db.categories.Update(category);
                TempData["Success"] = "Category Updated SuccessFully";
                _Db.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
