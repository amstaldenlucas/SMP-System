using System;

namespace SMPSystem.Models
{
    public class ProductProductionSteps
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public int ExecutionOrder { get; set; }
        public int ProductionTimeInSeconds { get; set; }
        public int MaximumProductionTimeInSeconds { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductionStepId { get; set; }
        public ProductionStep ProductionStep { get; set; }
    }
}
