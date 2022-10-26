using HomeTest.Data;
using HomeTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomeTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Database _context;
        private IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger,Database context, IWebHostEnvironment environment)
        {
            this._context = context;
            this._environment = environment;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.ClientCount = _context.Clients.Count();
            ViewBag.LocationCount = _context.Locations.Count();
            return View();
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