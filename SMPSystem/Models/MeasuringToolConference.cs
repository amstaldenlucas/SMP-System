using System;

namespace SMPSystem.Models
{
    public class MeasuringToolConference
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public double DefaultValue { get; set; }
        public double RegisteredValue { get; set; }
        public double Diference => DefaultValue - RegisteredValue;
        public bool Aproved { get; set; }
        public bool Adjusted { get; set; }

        public string MeasuringToolId { get; set; }
        public MeasuringTool MeasuringTool { get; set; }
        public string DbUserId { get; set; }
        public DbUser DbUser { get; set; }
    }
}
