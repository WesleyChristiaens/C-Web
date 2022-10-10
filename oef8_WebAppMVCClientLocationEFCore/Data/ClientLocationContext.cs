using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using oef8_WebAppMVCClientLocationEFCore.Models;
using System.Data.Common;
using System.Numerics;

namespace oef8_WebAppMVCClientLocationEFCore.Data
{
    public class ClientLocationContext : DbContext
    {  

        public ClientLocationContext(DbContextOptions<ClientLocationContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}
