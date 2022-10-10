using Microsoft.AspNetCore.Mvc;
using Oef07_MVC_Custom_Model_Validation.Data;
using Oef07_MVC_Custom_Model_Validation.Models;

namespace Oef07_MVC_Custom_Model_Validation.Controllers
{
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View(LocalData.Locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Location c = new Location();
            return View(c);
        }


        [HttpPost]
        public IActionResult Create(Location l)
        {
            if (ModelState.IsValid)
            {
                LocalData.Locations.Add(l);
                return RedirectToAction("Index");
            }

            return View("Create");
        }
    }
}
