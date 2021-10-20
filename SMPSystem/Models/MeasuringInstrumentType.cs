using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Models
{
    public class MeasuringInstrumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }

        public ICollection<MeasuringInstrument> MeasuringInstruments { get; set; }
    }
}
