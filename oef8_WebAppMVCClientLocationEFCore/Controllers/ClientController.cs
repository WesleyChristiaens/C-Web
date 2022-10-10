using Microsoft.AspNetCore.Mvc;
using oef8_WebAppMVCClientLocationEFCore.Data;
using oef8_WebAppMVCClientLocationEFCore.Models;

namespace oef8_WebAppMVCClientLocationEFCore.Controllers
{
    public class ClientController : Controller
    {
        ClientLocationContext _context;
        private IWebHostEnvironment _environment;

        public ClientController(ClientLocationContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _context.Database.EnsureCreated();           
            _environment = environment;
        }


        public IActionResult Index()
        {
            var Clients = _context.Clients;
            return View(Clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var c = new Client();
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Client c)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        public IActionResult Delete()
        {
            
            _context.Clients.Remove(c);
            _context.SaveChanges();

            return View("Index");
        }

    }
}
