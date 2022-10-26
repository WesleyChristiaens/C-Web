using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.Models.ViewModels;

namespace MVCVoertuig.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            return View();
        }
        #endregion

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult REgister(LoginViewModel user)
        {
            return View();
        } 
        #endregion
    }
}
