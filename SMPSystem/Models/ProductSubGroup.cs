using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Models
{
    public class ProductSubGroup
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

        public string ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
