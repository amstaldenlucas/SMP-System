using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMPSystem.Models
{
    public class MeasuringHistory
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(12,4)")]
        public double Measuring { get; set; }
        public int ProducedQuantity { get; set; }

        public int ProductionOrderId { get; set; }
        public int ProductId { get; set; }
        public string DbUserId { get; set; }
        public int MeasuringToolId { get; set; }
        public int ProductStepDimensionId { get; set; }
        public int ProductionStepId { get; set; }
        public ProductStepDimension ProductStepDimension { get; set; }
    }
}
