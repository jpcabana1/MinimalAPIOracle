namespace MinimalAPIOracle.Models
{
    public class ProductDetailsDAO
    {
        public decimal CustomerId { get; set; }
        public decimal OrderId { get; set; }
        public string Status { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public string? Description { get; set; }
    }
}
