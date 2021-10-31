using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.ViewModels
{
    public class ProductionOrderVm
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime PrevisionDate { get; set; }
        public bool FinalizedStatus { get; set; }
        public int TotalQuantity { get; set; }
        public int ProducedQuantity { get; set; }
        public int LostQuantity { get; set; }
        public string Obs { get; set; }
        public bool Status { get; set; }

        public int DbUserId { get; set; }
        public List<SelectListItem> DbUserOptions { get; set; }

        public int ProductId { get; set; }
        public List<SelectListItem> ProductOptions { get; set; }
    }
}
