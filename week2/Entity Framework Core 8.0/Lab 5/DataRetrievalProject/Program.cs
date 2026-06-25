using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataRetrievalProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Lab 5: Asynchronous Data Retrieval ===");

            using var context = new AppDbContext();
            
            // Re-create the database clean and seed data to query against
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };
            await context.Categories.AddRangeAsync(electronics, groceries);

            var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
            var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
            await context.Products.AddRangeAsync(product1, product2);
            await context.SaveChangesAsync();

            Console.WriteLine("[EF Core]: Initial data seeded. Executing retrieval routines...\n");

            // ----------------------------------------------------
            // Step 1: Retrieve All Products using ToListAsync
            // ----------------------------------------------------
            Console.WriteLine("--- 1. All Products ---");
            var products = await context.Products.ToListAsync();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - ₹{p.Price}");
            }
            Console.WriteLine();

            // ----------------------------------------------------
            // Step 2: Find by ID using FindAsync
            // ----------------------------------------------------
            Console.WriteLine("--- 2. Find by ID (1) ---");
            var product = await context.Products.FindAsync(1);
            Console.WriteLine($"Found: {product?.Name}");
            Console.WriteLine();

            // ----------------------------------------------------
            // Step 3: FirstOrDefault with Condition
            // ----------------------------------------------------
            Console.WriteLine("--- 3. FirstOrDefault (Price > 50000) ---");
            var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
            Console.WriteLine($"Expensive: {expensive?.Name}");
            
            Console.WriteLine("\nLab 5 execution complete.");
        }
    }
}