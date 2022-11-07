using Microsoft.AspNetCore.Mvc;

namespace MVCGroentenEnFruit.Controllers
{
    public class AccountController : Controller
    {
        #region register
        [HttpGet]
        public IActionResult Register()
        {

            //Roles
            return View();
        }

        /*[HttpPost]
        public IActionResult Register(RegisterViewModel)
        {
            //Create IdentityUser
            return View();
        }*/
        #endregion
        #region login

        #endregion
        #region logout

        #endregion
    }
}
