using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;
using WebAppMvcClientLocation_oefening4.Data;
using WebAppMvcClientLocation_oefening4.Models;

namespace WebAppMvcClientLocation_oefening4.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View(Database.Clients);
        }

        public IActionResult Create()
        {
            Client c = new Client();
            return View(c);
        }

        [HttpPost]
        public IActionResult AddClient(Client c)
        {
            if (ModelState.IsValid)
            {
                var action = Database.AddClient(c);
               

                if (!action.succeeded)
                {
                    ModelState.AddModelError("", action.Errors[0]);
                    return View("Create", c);
                }

                return RedirectToAction("Index", "Clients");
            }
            else
            {
                return View("Create", c);                
            }
        }
    }
}
