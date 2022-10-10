using Microsoft.AspNetCore.Mvc;
using MVCPartyInvites.Data;
using MVCPartyInvites.Models;

namespace MVCPartyInvites.Controllers
{
    public class GastController : Controller
    {
        public IActionResult Index()
        {

            Gast g = new Gast();
            return View(g);
        }

        [HttpPost]
        public IActionResult Reservatie(Gast g)
        {
            if (ModelState.IsValid)
            {
                    if (g.Naam.Length < 2)
                    {
                        ModelState.AddModelError("", "Naam is te kort!");
                            return View("Index",g);                                  
                    }

                LocalData.GastList.Add(g);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index", g);
            }            
        }

       
    }
}
