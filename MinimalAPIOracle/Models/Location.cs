using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class Location
    {
        public Location()
        {
            Warehous = new HashSet<Warehous>();
        }

        public decimal LocationId { get; set; }
        public string Address { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? CountryId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<Warehous> Warehous { get; set; }
    }
}
