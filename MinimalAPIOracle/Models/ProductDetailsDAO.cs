namespace MinimalAPIOracle.Models
{
    public class ProductDetailsDAO
    {
        public decimal CustomerId { get; set; }
        public decimal OrderId { get; set; }
        public string Status { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
    }
}
