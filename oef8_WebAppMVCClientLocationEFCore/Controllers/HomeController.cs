using Microsoft.AspNetCore.Mvc;
using oef8_WebAppMVCClientLocationEFCore.Data;
using oef8_WebAppMVCClientLocationEFCore.Models;
using System.Diagnostics;

namespace oef8_WebAppMVCClientLocationEFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ClientLocationContext _context;
        private IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger,ClientLocationContext context,IWebHostEnvironment environment)
        {
            _logger = logger;
            this._context = context;
            this._environment = environment;
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