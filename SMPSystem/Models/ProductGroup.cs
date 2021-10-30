using System;
using System.Collections.Generic;

namespace SMPSystem.Models
{
    public class ProductGroup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

        public ICollection<ProductSubGroup> ProductSubGroups { get; set; }
    }
}
