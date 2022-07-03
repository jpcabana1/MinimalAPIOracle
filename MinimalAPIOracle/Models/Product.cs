using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            OrderItems = new HashSet<OrderItem>();
        }

        public decimal ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; } = null!;
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
