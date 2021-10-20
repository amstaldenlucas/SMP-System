﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

        public string ProviderId { get; set; }
        public virtual Provider Provider { get; set; }

        public string ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public string ProductSubGroupId { get; set; }
        public virtual ProductSubGroup ProductSubGroup { get; set; }
    }
}