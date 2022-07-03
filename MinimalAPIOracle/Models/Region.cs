﻿using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class Region
    {
        public Region()
        {
            Countries = new HashSet<Country>();
        }

        public decimal RegionId { get; set; }
        public string RegionName { get; set; } = null!;

        public virtual ICollection<Country> Countries { get; set; }
    }
}
