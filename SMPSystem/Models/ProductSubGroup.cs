using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Models
{
    public class ProductSubGroup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

        public int ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
    }
}
