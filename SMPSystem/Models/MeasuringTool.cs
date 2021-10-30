using System;

namespace SMPSystem.Models
{
    public class MeasuringTool
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpDate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

        public string MeasuringToolType { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
