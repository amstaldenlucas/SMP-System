using System;

namespace SMPSystem.Models
{
    public class ProductionOrder
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime PrevisionDate { get; set; }
        public bool FinalizedStatus { get; set; }
        public int TotalQuantity { get; set; }
        public int ProducedQuantity { get; set; }
        public int LostQuantity { get; set; }
        public string Obs { get; set; }
        public bool Status { get; set; }

        public int DbUserId { get; set; }
        public DbUser DbUser { get; set; }

        public int ProductionStepId { get; set; }
        public ProductionStep ProductionStep { get; set; }



    }
}
