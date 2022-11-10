using Microsoft.AspNetCore.Identity;
using MVCGroentenEnFruit.Models.Data;

namespace MVCGroentenEnFruit.Data.DefaultData
{
    public static class SeedData
    {


        public static async void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await VoegRollenToeAsync(_context, _roleManager);
            }
        }

        private static void VoegStandaardArtikelsToe(AppDbContext context)
        {
            Artikel a = new Artikel();

        }

        private static async Task VoegRolToeAsync(RoleManager<IdentityRole> _roleManager,string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }
        }

        private static async Task VoegRollenToeAsync(AppDbContext _context,RoleManager<IdentityRole> _roleManager)
        {
            if(!_context.Roles.Any())
            {
                await VoegRolToeAsync(_roleManager, Roles.aankoper);
                await VoegRolToeAsync(_roleManager, Roles.verkoper);
            }
        }
    }
}
