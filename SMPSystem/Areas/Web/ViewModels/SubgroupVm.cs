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
