using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Models
{
    public class ProductStepDimension
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpDate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

        public string DimentionType { get; set; }
        public string MeasuringToolType { get; set; }
        public decimal MinimalValue { get; set; }
        public decimal MaximaumValue { get; set; }
        public string Obs { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductionStepId { get; set; }
        public ProductionStep ProductionStep { get; set; }
    }
}
