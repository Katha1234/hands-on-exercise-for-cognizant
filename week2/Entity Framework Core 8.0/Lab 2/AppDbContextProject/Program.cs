using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppDbContextProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Lab 2: Setting Up the AppDbContext (SQLite) ===");
            using (var context = new AppDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var cat = new Category { Name = "Electronics" };
                var prod = new Product { Name = "Gaming Mouse", Price = 49.99m, Category = cat };

                context.Categories.Add(cat);
                context.Products.Add(prod);
                context.SaveChanges();

                var savedCat = context.Categories.Include(c => c.Products).First();
                Console.WriteLine($"[EF Core]: Category '{savedCat.Name}' containing {savedCat.Products.Count} product(s) mapped cleanly.");
            }
            Console.WriteLine("Lab 2 execution complete.");
        }
    }
}