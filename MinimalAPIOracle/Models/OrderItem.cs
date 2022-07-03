using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class OrderItem
    {
        public decimal OrderId { get; set; }
        public long ItemId { get; set; }
        public decimal ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
