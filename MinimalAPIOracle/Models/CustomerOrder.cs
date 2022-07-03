using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class CustomerOrder
    {
        public decimal? CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? ProductName { get; set; }
    }
}
