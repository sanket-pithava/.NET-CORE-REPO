using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class deleteModel : PageModel
    {
        private readonly ApplicationDBContext _Db;
        public Category? category { get; set; }
        public deleteModel(ApplicationDBContext db)
        {
            _Db = db;
        }
        public void OnGet(int? Id)
        {
            if(Id!=null && Id!=0)
            {
                category = _Db.categories.Find(Id);
            }
        }
        public IActionResult OnPost(int? Id)
        {
            if (Id == null && Id == 0)
            {
                return NotFound();
            }
            category = _Db.categories.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            _Db.categories.Remove(category);
            TempData["Success"] = "Category Deleted SuccessFully";
            _Db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
