using Microsoft.EntityFrameworkCore;
using RetailInventoryApp.Models;

namespace RetailInventoryApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RetailInventoryDB;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
