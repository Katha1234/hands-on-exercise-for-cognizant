using Microsoft.EntityFrameworkCore;

namespace MigrationProject
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // The database file that migrations will target
            optionsBuilder.UseSqlite("Data Source=inventory_migration.db");
        }
    }
}