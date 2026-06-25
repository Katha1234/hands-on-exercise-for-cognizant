using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataInsertionProject
{
    class Program
    {
        // Notice the 'async Task' signature enabling asynchronous executions
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Lab 4: Asynchronous Data Insertion ===");

            using var context = new AppDbContext();
            
            // Re-create the database clean for a reliable run
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            // 1. Create Category Entities
            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };

            // 2. Queue categories into tracking memory asynchronously
            await context.Categories.AddRangeAsync(electronics, groceries);

            // 3. Create Product Entities linked directly to Category instances
            var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
            var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

            // 4. Queue products into tracking memory asynchronously
            await context.Products.AddRangeAsync(product1, product2);

            // 5. Push changes and execute the database transaction unit
            Console.WriteLine("[EF Core]: Flushing data to database file asynchronously...");
            await context.SaveChangesAsync();
            Console.WriteLine("[EF Core]: Data records inserted successfully!\n");

            // 6. Verify the insertion inside the console log
            Console.WriteLine("--- Verification Scan ---");
            var productsInDb = await context.Products.Include(p => p.Category).ToListAsync();
            foreach (var p in productsInDb)
            {
                Console.WriteLine($"Product: {p.Name,-10} | Price: {p.Price,7} | Category: {p.Category.Name}");
            }
            
            Console.WriteLine("\nLab 4 execution complete.");
        }
    }
}