using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class Inventory
    {
        public decimal ProductId { get; set; }
        public decimal WarehouseId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Warehous Warehouse { get; set; } = null!;
    }
}
