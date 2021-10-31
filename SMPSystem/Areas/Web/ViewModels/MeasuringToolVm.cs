using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace SMPSystem.Areas.Web.ViewModels
{
    /// <summary>
    /// <see cref="SMPSystem.Models.MeasuringTool" />
    /// </summary>
    public class MeasuringToolVm
    {
        public int Id { get; set; }
        public DateTime LastUpDate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

        public string MeasuringToolType { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> MeasuringToolTypeOptions { get; set; }
    }
}
