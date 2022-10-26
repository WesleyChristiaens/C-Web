using HomeTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeTest.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Location> Locations { get; set; }
    }
}
