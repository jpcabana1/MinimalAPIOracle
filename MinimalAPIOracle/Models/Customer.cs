using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Contacts = new HashSet<Contact>();
            Orders = new HashSet<Order>();
        }

        public decimal CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Website { get; set; }
        public decimal? CreditLimit { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
