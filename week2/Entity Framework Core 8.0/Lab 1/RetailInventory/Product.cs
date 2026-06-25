namespace RetailInventory
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int StockLevel { get; set; }
        public decimal Price { get; set; }
    }
}