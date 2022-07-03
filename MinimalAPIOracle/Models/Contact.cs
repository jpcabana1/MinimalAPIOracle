using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class Contact
    {
        public decimal ContactId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public decimal? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
