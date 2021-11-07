using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMPSystem.Areas.Web.ViewModels
{
    /// <summary>
    /// <see cref="SMPSystem.Models.ProductProductionStep" />
    /// </summary>
    public class ProductProductionStepsVm
    {
        public int Id { get; set; }
        [Display(Name = "Última atualização")]
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        [Display(Name = "Inativo")]
        public bool Deleted { get; set; }
        [Display(Name = "Ordem de Execução")]
        public int ExecutionOrder { get; set; }
        [Display(Name = "Tempo de produção")]
        public int ProductionTimeInSeconds { get; set; }
        [Display(Name = "Tempo máximo de produção")]
        public int MaximumProductionTimeInSeconds { get; set; }

        [Display(Name = "Produto")]
        public int ProductId { get; set; }
        [Display(Name = "Produto")]
        public List<SelectListItem> ProductOptions { get; set; } = new List<SelectListItem>();

        [Display(Name = "Operação")]
        public int ProductionStepId { get; set; }
        [Display(Name = "Operação")]
        public List<SelectListItem> ProductionStepOptions { get; set; } = new List<SelectListItem>();
    }
}
