using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Models.Data;
namespace MVCVoertuig.Data
{
    public class VoertuigDbContext : DbContext
    {
        public VoertuigDbContext(DbContextOptions<VoertuigDbContext> options) : base(options) 
        { }        
        public DbSet<Voertuig> Voertuigen { get; set; }
    }
}
