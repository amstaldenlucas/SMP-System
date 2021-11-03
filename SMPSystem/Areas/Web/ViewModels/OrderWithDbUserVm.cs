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
    public class OrderWithDbUserVm
    {
        public string DbUserId { get; set; }
        public int ProductionOrderId { get; set; }
        [Display(Name = "Código Ordem Produção")]
        public int ProductionOrderCode { get; set; }
        public int ProductId { get; set; }
        public int OrderProductStepId { get; set; }

        [Display(Name = "Usuário PCP")]
        public DbUser DbUser { get; set; }
        [Display(Name = "Ordem de Produção")]
        public ProductionOrder ProductionOrder { get; set; }
        [Display(Name = "Operação")]
        public OrderProductStep OrderProductStep { get; set; }
        [Display(Name = "Usuário")]
        public List<SelectListItem> DbUserOptions { get; set; }
    }
}
