using Microsoft.AspNetCore.Mvc;
using WebAppMvcClientLocation_oefening4.Models;

namespace WebAppMvcClientLocation_oefening4.Controllers
{
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            Location l = new Location();
            return View(l);
        }

        [HttpPost]
        public IActionResult Create(Location l)
        {

            if(ModelState.IsValid)
            {
                if (l)
                {

                }
            }
            


            return View(l);
        }
    }
}
