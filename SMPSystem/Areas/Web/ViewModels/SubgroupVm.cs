﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

        [Display(Name = "Grupo")]
        public int ProductGroupId { get; set; }
        public List<SelectListItem> Groups { get; set; } = new List<SelectListItem>();
    }
}
