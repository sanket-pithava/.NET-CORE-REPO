using System.Diagnostics;
using BulkyWeb.DataAccess.Repository.IRepository;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.FrontCustomer.Controllers
{
    [Area("FrontCustomer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitofwork _unitofwork;
        public HomeController(ILogger<HomeController> logger , IUnitofwork unitofwork)
        {
            _logger = logger;
            _unitofwork = unitofwork;   
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitofwork.product.GetAll(includePropeties: "catogery").ToList();
            return View(products);
        }
        public IActionResult Details(int productId)
        {
            Product products = _unitofwork.product.Get(u => u.Id == productId);
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
