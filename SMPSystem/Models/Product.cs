using System;
using System.ComponentModel.DataAnnotations;

namespace SMPSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

        public int? ProviderId { get; set; }
        public Provider Provider { get; set; }
        
        public int? ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        
        public int? ProductSubGroupId { get; set; }
        public ProductSubGroup ProductSubGroup { get; set; }
    }
}
