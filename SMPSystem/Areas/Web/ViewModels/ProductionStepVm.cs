using System.ComponentModel.DataAnnotations;

namespace SMPSystem.Areas.Web.ViewModels
{
    /// <summary>
    /// <see cref="SMPSystem.Models.ProductionStep" />
    /// </summary>
    public class ProductionStepVm
    {
        public int Id { get; set; }
        [Display(Name = "Código")]
        public string Code { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Display(Name = "Inativo")]
        public bool Deleted { get; set; }
        [Display(Name = "ordem de Execução")]
        public int ExecutionOrder { get; set; }
    }
}
