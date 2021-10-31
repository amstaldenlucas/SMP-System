using Microsoft.AspNetCore.Mvc.Rendering;
using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.ViewModels
{
    public class ProductStepDimensionVm
    {
        public int Id { get; set; }
        public DateTime LastUpDate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

        public string MeasuringDimensionType { get; set; }
        public string MeasuringToolType { get; set; }

        [Column(TypeName = "decimal(12,4)")]
        public decimal MinimalValue { get; set; }

        [Column(TypeName = "decimal(12,4)")]
        public decimal MaximaumValue { get; set; }
        public string Obs { get; set; }

        public int ProductId { get; set; }
        public List<SelectListItem> ProductOptions { get; set; }

        public int ProductionStepId { get; set; }
        public List<SelectListItem> ProductionStepOptions { get; set; }

        public List<SelectListItem> DimensionTypeOptions { get; set; }
        public List<SelectListItem> MeasuringToolTypeOptions { get; set; }
    }
}
