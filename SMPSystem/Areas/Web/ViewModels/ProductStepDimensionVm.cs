using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMPSystem.Areas.Web.ViewModels
{
    /// <summary>
    /// <see cref="SMPSystem.Models.ProductStepDimension" />
    /// </summary>
    public class ProductStepDimensionVm
    {
        public int Id { get; set; }
        [Display(Name = "Ultima atualização")]
        public DateTime LastUpDate { get; set; } = DateTime.Now;
        [Display(Name = "Inativo")]
        public bool Deleted { get; set; }
        [Display(Name = "Tipo de Dimensão")]
        public string MeasuringDimensionType { get; set; }
        [Display(Name = "Tipo de instrumento de medida")]
        public string MeasuringToolType { get; set; }

        [Display(Name = "Valor mínimo")]
        [Column(TypeName = "decimal(12,4)")]
        public decimal MinimalValue { get; set; }

        [Display(Name = "Valor máximo")]
        [Column(TypeName = "decimal(12,4)")]
        public decimal MaximaumValue { get; set; }
        
        [Display(Name = "Frequência de registro de medição (quantidade)")]
        public int FrequencyToMeasureInQuantity { get; set; }
        [Display(Name = "Frequência de registro de medição (tempo em minutos)")]
        public int FrequencyToMeasureInMinutes { get; set; }
        [Display(Name = "Observação")]
        public string Obs { get; set; }

        [Display(Name = "Produto")]
        public int ProductId { get; set; }
        [Display(Name = "Produto")]
        public List<SelectListItem> ProductOptions { get; set; }

        [Display(Name = "Operação")]
        public int ProductionStepId { get; set; }
        [Display(Name = "Operação")]
        public List<SelectListItem> ProductionStepOptions { get; set; }

        [Display(Name = "Tipo Dimensão")]
        public List<SelectListItem> DimensionTypeOptions { get; set; }
        [Display(Name = "Instrumento medição")]
        public List<SelectListItem> MeasuringToolTypeOptions { get; set; }
    }
}
