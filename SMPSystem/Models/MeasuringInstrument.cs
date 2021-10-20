using System;

namespace SMPSystem.Models
{
    public class MeasuringInstrument
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }
        public DateTime LastConference { get; set; }
        public DateTime NextConference { get; set; }

        public string MeasuringInstrumentTypeId { get; set; }
        public virtual MeasuringInstrumentType MeasuringInstrumentType { get; set; }
    }
}
