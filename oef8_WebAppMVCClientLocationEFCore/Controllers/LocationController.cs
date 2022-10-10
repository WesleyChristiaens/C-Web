using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oef8_WebAppMVCClientLocationEFCore.Data;
using oef8_WebAppMVCClientLocationEFCore.Models;

namespace oef8_WebAppMVCClientLocationEFCore.Controllers
{
    public class LocationController : Controller
    {
        ClientLocationContext _context;
        private IWebHostEnvironment _environment;

        public LocationController(ClientLocationContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _environment = environment;
        }

        public IActionResult Index()
        {
            var Locations = _context.Locations;
            return View(Locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var l = new Location();
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Location l)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Add(l);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l);

        }
    }
}
