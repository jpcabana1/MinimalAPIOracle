using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public decimal OrderId { get; set; }
        public decimal CustomerId { get; set; }
        public string Status { get; set; } = null!;
        public decimal? SalesmanId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Employee? Salesman { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
