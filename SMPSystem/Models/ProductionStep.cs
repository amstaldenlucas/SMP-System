using System;

namespace SMPSystem.Models
{
    public class ProductionStep
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpDate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }
    }
}
