using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace SMPSystem.Areas.Web.ViewModels
{
    /// <summary>
    /// <see cref="SMPSystem.Models.ProductProductionStep" />
    /// </summary>
    public class ProductProductionStepsVm
    {
        public int Id { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }
        public int ExecutionOrder { get; set; }
        public int ProductionTimeInSeconds { get; set; }
        public int MaximumProductionTimeInSeconds { get; set; }

        public int ProductId { get; set; }
        public List<SelectListItem> ProductOptions { get; set; } = new List<SelectListItem>();
        public int ProductionStepId { get; set; }

        public List<SelectListItem> ProductionStepOptions { get; set; } = new List<SelectListItem>();
    }
}
