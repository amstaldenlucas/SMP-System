using System;
using System.ComponentModel.DataAnnotations;

namespace SMPSystem.Models
{
    public class Provider
    {
        public int Id { get; set; }
        [Display(Name = "Código")]
        public string Code { get; set; }
        [Display(Name = "CNPJ")]
        public string Document { get; set; }
        [Display(Name = "Razão Social")]
        public string Name { get; set; }
        [Display(Name = "Nome Fantasia")]
        public string TradingName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }
    }
}
