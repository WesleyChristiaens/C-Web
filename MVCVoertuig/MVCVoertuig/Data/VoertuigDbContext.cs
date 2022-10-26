using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Models.Data;
using MVCVoertuig.Models.ViewModels;
namespace MVCVoertuig.Data
{
    public class VoertuigDbContext : IdentityDbContext
    {
        public VoertuigDbContext(DbContextOptions<VoertuigDbContext> options) : base(options)
        { }
        public DbSet<Voertuig> Voertuigen { get; set; }
     

    }
}
