using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCGroentenEnFruit.Data;
using MVCGroentenEnFruit.Models.ViewModels;

namespace MVCGroentenEnFruit.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public AccountController(AppDbContext context,UserManager<IdentityUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        #region register
        [HttpGet]
        public IActionResult Register()
        {
            //Roles
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                if(rvm.RoleId != null)
                {
                    var identityUser = new IdentityUser();
                    identityUser.Email = rvm.Email;
                    identityUser.UserName = rvm.Email;
                    var identityResult = await _userManager.CreateAsync(identityUser,rvm.Passwoord);

                    if (identityResult.Succeeded)
                    {
                        var roleResult = await _userManager.AddToRoleAsync(identityUser, rvm.RoleId);

                        if(roleResult.Succeeded)
                        {
                            return View("Login");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Probleem met toekennen van rol.");
                            return View();
                        }
                        
                    }
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Geen rol geselecteerd");
                }
            }
            return View();
        }
        #endregion
        #region login

        #endregion
        #region logout

        #endregion
    }
}
