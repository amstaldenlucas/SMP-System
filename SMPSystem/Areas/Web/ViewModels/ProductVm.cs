using Microsoft.AspNetCore.Mvc.Rendering;
using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMPSystem.Areas.Web.ViewModels
{
    /// <summary>
    /// <see cref="SMPSystem.Models.Product" />
    /// </summary>
    public class ProductVm
    {
        public ProductVm()
        {
        }

        public ProductVm(List<SelectListItem> providers, List<SelectListItem> groups, List<SelectListItem> subgroups)
        {
            Providers = providers;
            Groups = groups;
            SubGroups = subgroups;
        }

        public int Id { get; set; }

        [Display(Name = "Código")]
        public string Code { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Deletado")]
        public bool Deleted { get; set; }
        [Display(Name = "Criação")]
        public DateTime Created { get; set; }

        [Display(Name = "Fornecedor")]
        public Provider Provider { get; set; }

        public string ProviderId { get; set; }
        [Display(Name = "Fornecedores")]
        public List<SelectListItem> Providers { get; set; } = new List<SelectListItem>();

        [Display(Name = "Grupo")]
        public string ProductGroupId { get; set; }
        [Display(Name = "Grupo")]
        public List<SelectListItem> Groups { get; set; } = new List<SelectListItem>();

        [Display(Name = "Subgrupos")]
        public string ProductSubGroupId { get; set; }
        [Display(Name = "Grupo")]
        public List<SelectListItem> SubGroups { get; set; } = new List<SelectListItem>();
    }
}
