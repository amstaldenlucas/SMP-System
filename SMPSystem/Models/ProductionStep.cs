using System;
using System.ComponentModel.DataAnnotations;

namespace SMPSystem.Models
{
    public class ProductionStep
    {
        public int Id { get; set; }
        [Display(Name = "Código")]
        public string Code { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpDate { get; set; } = DateTime.Now;
        [Display(Name = "Deletado")]
        public bool Deleted { get; set; }
    }
}
