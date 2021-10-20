using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Models
{
    public class MeasuringInstrumentConference
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public double DefaultValue { get; set; }
        public double RegisteredValue { get; set; }
        public double Diference => DefaultValue - RegisteredValue;
        public bool Aproved { get; set; }
        public bool Adjusted { get; set; }

        public string MeasuringInstrumentId { get; set; }
        public MeasuringInstrument MeasuringInstrument { get; set; }
        public string DbUserId { get; set; }
        public DbUser DbUser { get; set; }
    }
}
