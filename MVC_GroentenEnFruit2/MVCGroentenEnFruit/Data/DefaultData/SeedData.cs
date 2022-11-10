using Microsoft.AspNetCore.Identity;
using MVCGroentenEnFruit.Models.Data;

namespace MVCGroentenEnFruit.Data.DefaultData
{
    public static class SeedData
    {
        static AppDbContext? _context;
        static RoleManager<IdentityRole>? _roleManager;
        static UserManager<IdentityUser>? _userManager;
        public static async Task EnsurePopulatedAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await VoegRollenToeAsync();
                await CreateIdentityRecordAsync(Roles.Aankoper, "aankoper@pxl.be", "Aankoper00!", Roles.Aankoper);
                await CreateIdentityRecordAsync(Roles.Verkoper, "verkoper@pxl.be", "Verkoper00!", Roles.Verkoper);
                VoegStandaardArtikelsToe();
            }           
        }
        private static void VoegStandaardArtikelsToe()
        {
            if (_context != null && _context.Artikels != null)
            {
                if (!_context.Artikels.Any())
                {
                    Artikel a = new Artikel() { Naam = "Ijsbergsla" };
                    _context.Artikels.Add(a);
                    a = new Artikel() { Naam = "Roma tomaat" };
                    _context.Artikels.Add(a);
                    _context.SaveChanges();
                }
            }

        }
        private static async Task VoegRollenToeAsync()
        {
            if(_roleManager != null && !_roleManager.Roles.Any())  
            {
                await VoegRolToeAsync( Roles.Aankoper);
                await VoegRolToeAsync( Roles.Verkoper);
            }
        }
        private static async Task VoegRolToeAsync(string roleName)
        {
            if (_roleManager != null &&  !await _roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }
        }
        private static async Task CreateIdentityRecordAsync(string userName, string email, string pwd, string role)
        {
            
            if (_userManager != null && await _userManager.FindByEmailAsync(email) == null &&
                    await _userManager.FindByNameAsync(userName) == null)
            {
                var identityUser = new IdentityUser() { Email = email, UserName = userName};
                var result = await _userManager.CreateAsync(identityUser, pwd);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, role);
                }
            }
        }
    }
}

