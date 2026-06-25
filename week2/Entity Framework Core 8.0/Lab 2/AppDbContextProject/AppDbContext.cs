using Microsoft.EntityFrameworkCore;

namespace AppDbContextProject
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Separate database file for Lab 2
            optionsBuilder.UseSqlite("Data Source=retail_inventory_l2.db");
        }
    }
}