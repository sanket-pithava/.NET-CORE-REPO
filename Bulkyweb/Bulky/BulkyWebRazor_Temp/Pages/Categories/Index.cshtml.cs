using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public List<Category> CategoriesList { get; set; }    
        public IndexModel(ApplicationDBContext Db)
        {
            _applicationDBContext = Db;
        }
        public void OnGet()
        {
            CategoriesList = _applicationDBContext.categories.ToList();
        }
    }
}
