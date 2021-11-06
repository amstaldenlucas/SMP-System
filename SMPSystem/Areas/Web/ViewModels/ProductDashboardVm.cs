using Microsoft.AspNetCore.Mvc.Rendering;
using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.ViewModels
{
    public class ProductDashboardVm
    {
        [Display(Name = "Produto")]
        public List<SelectListItem> ProductOptions { get; set; }
        [Display(Name = "Operação")]
        public List<SelectListItem> ProductionStepOptions { get; set; }
        public List<MeasuringHistory> MeasuringHistories { get; set; } = new List<MeasuringHistory>();

        public int ProductId { get; set; }
        public int ProductionStepId { get; set; }
        [Display(Name = "Orderm Produção")]
        public int OrderCode { get; set; }

        public int ProductStepDimensionId { get; set; }

        [Display(Name = "Dimensão")]
        public List<SelectListItem> ProductStepDimensions { get; set; }

        public string ProductName { get; set; }
    }
}
