using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.Models.ViewModels;


namespace MVCVoertuig.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signinManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager)
        {
            this._userManager = userManager;
            this._signinManager = signinManager;
        }


        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var signinResult = await _signinManager.PasswordSignInAsync(login.Email, login.Password, false, lockoutOnFailure: false);

            if (signinResult.Succeeded)
            {
                return RedirectToAction("Index", "Voertuig");
            }
            ModelState.AddModelError("", "Probleem met inloggen");


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
        public async Task<IActionResult> Register(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser();
                identityUser.Email = user.Email;
                identityUser.UserName = user.Email;
                var identityResult = await _userManager.CreateAsync(identityUser, user.Password);

                if (identityResult.Succeeded)
                {
                    return View("RegistrationCompleted");
                }
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        #endregion



        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Login","Voertuig");
        }

    }
}
