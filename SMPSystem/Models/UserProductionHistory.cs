using System;

namespace SMPSystem.Models
{
    public class UserProductionHistory
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public int ProductionOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ProductionStepId { get; set; }
        public bool Status { get; set; }
        public int ProducedQuantity { get; set; }

    }
}
