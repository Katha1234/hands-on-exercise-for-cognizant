using System;
using System.Linq;

namespace RetailInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Lab 1: Understanding ORM (SQLite) ===");
            using (var context = new InventoryContext())
            {
                context.Database.EnsureCreated();
                if (!context.Products.Any())
                {
                    context.Products.Add(new Product { Name = "Keyboard", Category = "Electronics", StockLevel = 45, Price = 89.99m });
                    context.SaveChanges();
                    Console.WriteLine("[ORM]: Seeded default product data successfully!");
                }
                foreach (var product in context.Products.ToList())
                {
                    Console.WriteLine($"-> {product.Name} | Stock: {product.StockLevel} units | Price: ${product.Price}");
                }
            }
            Console.WriteLine("Lab 1 execution complete.");
        }
    }
}