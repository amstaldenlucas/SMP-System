using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMPSystem.Areas.Web.ViewModels
{
    /// <summary>
    /// <see cref="SMPSystem.Models.MeasuringTool" />
    /// </summary>
    public class MeasuringToolVm
    {
        public int Id { get; set; }
        [Display(Name = "Última Atualização")]
        public DateTime LastUpDate { get; set; } = DateTime.Now;
        [Display(Name = "Inativo")]
        public bool Deleted { get; set; }
        [Display(Name = "Tipo de instrumento")]
        public string MeasuringToolType { get; set; }
        [Display(Name = "Código")]
        public string Code { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Opções de instrumento")]
        public List<SelectListItem> MeasuringToolTypeOptions { get; set; }
    }
}
