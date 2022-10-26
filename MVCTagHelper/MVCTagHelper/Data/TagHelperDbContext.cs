using Microsoft.EntityFrameworkCore;
using MVCTagHelper.Models;

namespace MVCTagHelper.Data
{
    public class TagHelperDbContext : DbContext
    {
        public TagHelperDbContext(DbContextOptions<TagHelperDbContext> options) : base(options) { }
        public DbSet<Afdeling> Afdelingen { get; set; }
        public DbSet<Land> Landen { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
        public DbSet<MVCTagHelper.Models.Medewerker> Medewerker { get; set; }
    }
}
