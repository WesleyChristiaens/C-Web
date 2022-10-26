using Microsoft.EntityFrameworkCore;
using MVC_sportstore.Models.Data;

namespace MVC_sportstore.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }



    }
}
