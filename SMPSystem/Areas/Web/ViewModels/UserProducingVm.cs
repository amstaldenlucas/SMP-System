using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.ViewModels
{
    public class UserProducingVm
    {
        public string DbUserId { get; set; }
        public int ProductId { get; set; }
        public int ProductionOrderId { get; set; }
        public int ProductionStepId { get; set; }
        [Display(Name = "Número ordem de produção")]
        public int ProductionOrderCode { get; set; }
        [Display(Name = "Ordem de produção")]
        public ProductionOrder Order { get; set; }
        [Display(Name = "Usuário")]
        public DbUser DbUser { get; set; }
        [Display(Name = "Produto")]
        public Product Product { get; set; }
        [Display(Name = "Opração")]
        public OrderProductStep OrderProductStep { get; set; }
        [Display(Name = "Acompanhamento de produção")]
        public UserProductionHistory UserProductionHistory { get; set; }
        [Display(Name = "Acompanhamento de medidas")]
        public List<MeasuringHistory> MeasuringHistories { get; set; } = new List<MeasuringHistory>();
        [Display(Name = "Medidas")]
        public List<ProductStepDimension> DimensionsToCheck { get; set; } = new List<ProductStepDimension>();
    }
}
