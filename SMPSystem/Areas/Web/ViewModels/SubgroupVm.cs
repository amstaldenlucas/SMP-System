using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMPSystem.Areas.Web.ViewModels
{
    /// <summary>
    /// <see cref="SMPSystem.Models.ProductSubGroup" />
    /// </summary>
    public class SubgroupVm
    {
        public int Id { get; set; }
        [Display(Name = "Código")]
        public string Code { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Criação")]
        public DateTime Created { get; set; } = DateTime.Now;
        [Display(Name = "Última atualização")]
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        [Display(Name = "Inativo")]
        public bool Deleted { get; set; }

        public int ProductGroupId { get; set; }
        [Display(Name = "Grupos")]
        public List<SelectListItem> Groups { get; set; } = new List<SelectListItem>();
    }
}
