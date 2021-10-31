using Microsoft.AspNetCore.Mvc.Rendering;
using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.ViewModels
{
    public class OrderWithDbUserVm
    {
        public string DbUserId { get; set; }
        public int ProductionOrderId { get; set; }
        public int ProductionOrderCode { get; set; }
        public int ProductId { get; set; }
        public int OrderProductStepId { get; set; }

        public DbUser DbUser { get; set; }
        public ProductionOrder ProductionOrder { get; set; }
        public OrderProductStep OrderProductStep { get; set; }

        public List<SelectListItem> DbUserOptions { get; set; }
    }
}
