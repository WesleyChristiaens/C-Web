using Microsoft.AspNetCore.Mvc;
using MVCModelValidation.Data;
using MVCModelValidation.Models;

namespace MVCModelValidation.Controllers
{
    public class TestDataController : Controller
    {
        public IActionResult Index()
        {
            return View(LocalData.TestDataList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var testData = new TestData();
            return View(testData);
        }

        [HttpPost]
        public IActionResult Create(TestData testData)
        {
            if(ModelState.IsValid)
            {
                LocalData.TestDataList.Add(testData);
                return RedirectToAction("Index");
            }

            return View(testData);

        }
    }
}
