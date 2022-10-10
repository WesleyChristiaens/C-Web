using Microsoft.AspNetCore.Mvc;
using MVCModelValidation.Data;
using MVCModelValidation.Models;

namespace MVCModelValidation.Controllers
{
    public class TestValidationController : Controller
    {
       public IActionResult Index()
        {
            return View(LocalData.TestValList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var testval = new TestValidation();
            return View(testval);
        }

        [HttpPost]
        public IActionResult Create(TestValidation testval)
        {
            if (ModelState.IsValid)
            {
                LocalData.TestValList.Add(testval);
                return RedirectToAction("Index");
            }

            return View(testval);

        }
    }
}
