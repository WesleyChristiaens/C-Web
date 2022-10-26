using Microsoft.AspNetCore.Mvc;
using MVC_sportstore.Data;
using MVC_sportstore.Models;
using System.Diagnostics;

namespace MVC_sportstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StoreDbContext _context;
        private ProductRepository _repo;

        public HomeController(StoreDbContext context)
        {
           
            this._context = context;
            this._repo = new ProductRepository(_context);
        }

        public IActionResult Index(int id = 1,string category = null)
        {
            var productModel = _repo.GetProductModel(id,category);
            return View(productModel);
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