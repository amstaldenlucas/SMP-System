using SMPSystem.Models;
using System;
using System.Collections.Generic;
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
        public int ProductionOrderCode { get; set; }

        public ProductionOrder Order { get; set; }
        public DbUser DbUser { get; set; }
        public Product Product { get; set; }
        public OrderProductStep OrderProductStep { get; set; }

        public UserProductionHistory UserProductionHistory { get; set; }
        public List<MeasuringHistory> MeasuringHistories { get; set; } = new List<MeasuringHistory>();

        public List<ProductStepDimension> DimensionsToCheck { get; set; } = new List<ProductStepDimension>();
    }
}
