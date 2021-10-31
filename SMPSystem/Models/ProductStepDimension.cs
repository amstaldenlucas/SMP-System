using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMPSystem.Models
{
    public class ProductStepDimension
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpDate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

        public string MeasuringDimensionType { get; set; }
        public string MeasuringToolType { get; set; }
        [Column(TypeName = "decimal(12,4)")]
        public decimal MinimalValue { get; set; }
        [Column(TypeName = "decimal(12,4)")]
        public decimal MaximaumValue { get; set; }
        public string Obs { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductionStepId { get; set; }
        public ProductionStep ProductionStep { get; set; }
    }
}
