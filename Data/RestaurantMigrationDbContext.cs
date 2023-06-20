using Microsoft.EntityFrameworkCore;
using Reservation_Management.Models;
using System.Security.Cryptography.X509Certificates;

namespace Reservation_Management.Data
{
    public class RestaurantMigrationDbContext : DbContext
    {
        public RestaurantMigrationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Reservation> Reservation { get; set; }

        public DbSet<OrderTable> OrderTables { get; set; }

      
    }
}
