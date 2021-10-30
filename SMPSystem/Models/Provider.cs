using System;

namespace SMPSystem.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string TradingName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }
    }
}
