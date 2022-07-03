using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class Warehous
    {
        public Warehous()
        {
            Inventories = new HashSet<Inventory>();
        }

        public decimal WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public decimal? LocationId { get; set; }

        public virtual Location? Location { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
