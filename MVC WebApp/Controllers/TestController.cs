using Microsoft.AspNetCore.Mvc;
using MVC_WebApp.Models;

namespace MVC_WebApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestViewBag()
        {
            ViewBag.Teller = 3;
            ViewData["Teller"] = 3;
            return View();
        }

        public IActionResult Formulier()
        {
            return View();
        }

        public IActionResult FormulierPost()
        {
            string invoer = Request.Form["TestInvoer"];
            TestModel model = new TestModel();
            model.TestInvoer = invoer;
            return View(model);
            //Deze action verwijst naar onze Views/Test/FormulierPost.cshtml
        }
    }
}
