using System;

namespace ECommerceSearchSystem
{
    public class Product : IComparable<Product>
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(string productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return string.Compare(this.ProductName, other.ProductName, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"[ID: {ProductId} | Name: {ProductName} | Category: {Category}]";
        }
    }

    class Program
    {
        public static Product? LinearSearch(Product[] products, string targetName)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].ProductName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                    return products[i];
            }
            return null;
        }

        public static Product? BinarySearch(Product[] sortedProducts, string targetName)
        {
            int left = 0;
            int right = sortedProducts.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = string.Compare(sortedProducts[mid].ProductName, targetName, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0) return sortedProducts[mid];
                else if (comparison < 0) left = mid + 1;
                else right = mid - 1;
            }
            return null;
        }

        static void Main(string[] args)
        {
            Product[] inventory = new Product[]
            {
                new Product("P003", "Wireless Mouse", "Electronics"),
                new Product("P001", "Gaming Laptop", "Electronics"),
                new Product("P004", "Running Shoes", "Footwear"),
                new Product("P002", "Coffee Mug", "Kitchenware")
            };

            string searchTarget = "Running Shoes";

            Console.WriteLine("--- Executing Linear Search ---");
            Product? result1 = LinearSearch(inventory, searchTarget);
            Console.WriteLine(result1 != null ? $"Found: {result1}" : "Item not found.");

            Console.WriteLine("\n--- Sorting Array for Binary Search ---");
            Array.Sort(inventory);

            Console.WriteLine("--- Executing Binary Search ---");
            Product? result2 = BinarySearch(inventory, searchTarget);
            Console.WriteLine(result2 != null ? $"Found: {result2}" : "Item not found.");
        }
    }
}