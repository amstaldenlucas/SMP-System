using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMPSystem.Areas.Web.ViewModels
{
    /// <summary>
    /// <see cref="SMPSystem.Models.ProductionOrder" />
    /// </summary>
    public class ProductionOrderVm
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        public int Code { get; set; }
        [Display(Name = "Data Criação")]
        public DateTime Created { get; set; }
        [Display(Name = "Data última atualização")]
        public DateTime LastUpdate { get; set; }
        [Display(Name = "Previsão")]
        public DateTime PrevisionDate { get; set; } = DateTime.Now.AddDays(7);
        [Display(Name = "Finalizado")]
        public bool FinalizedStatus { get; set; }
        [Display(Name = "Quantidade Total")]
        public int TotalQuantity { get; set; }
        [Display(Name = "Quantidade Produzida")]
        public int ProducedQuantity { get; set; }
        [Display(Name = "Quantidade Perdida")]
        public int LostQuantity { get; set; }
        [Display(Name = "Observação")]
        public string Obs { get; set; }
        public bool Status { get; set; }

        public string DbUserId { get; set; }
        [Display(Name = "Opções de usuário")]
        public List<SelectListItem> DbUserOptions { get; set; }

        public int ProductId { get; set; }
        [Display(Name = "Opções de produto")]
        public List<SelectListItem> ProductOptions { get; set; }
    }
}
