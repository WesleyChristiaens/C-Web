using Microsoft.AspNetCore.Mvc;
using Oef07_MVC_Custom_Model_Validation.Data;
using Oef07_MVC_Custom_Model_Validation.Models;

namespace Oef07_MVC_Custom_Model_Validation.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View(LocalData.Clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Client c = new Client();
            return View(c);
        }


        [HttpPost]
        public IActionResult Create(Client c)
        {
            if (ModelState.IsValid)
            {
                LocalData.Clients.Add(c);
                return RedirectToAction("Index");
            }

            return View("Create");
        }
    }
}
