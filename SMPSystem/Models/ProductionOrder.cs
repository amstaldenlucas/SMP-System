using System;
using System.Collections.Generic;

namespace SMPSystem.Models
{
    public class ProductionOrder
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public DateTime PrevisionDate { get; set; }
        public bool FinalizedStatus { get; set; }
        public int TotalQuantity { get; set; }
        public int ProducedQuantity { get; set; }
        public int LostQuantity { get; set; }
        public string Obs { get; set; }

        public string DbUserId { get; set; }
        public DbUser DbUser { get; set; }

        public List<OrderProductStep> OrderProductSteps { get; set; } = new List<OrderProductStep>();
    }
}
