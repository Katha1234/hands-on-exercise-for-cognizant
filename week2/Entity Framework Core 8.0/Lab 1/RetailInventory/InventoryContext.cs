using Microsoft.EntityFrameworkCore;

namespace RetailInventory
{
    public class InventoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Using SQLite creates a local file named 'retail_inventory_l1.db' automatically!
            optionsBuilder.UseSqlite("Data Source=retail_inventory_l1.db");
        }
    }
}