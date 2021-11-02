using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.ViewModels
{
    /// <summary>
    /// <see cref="SMPSystem.Models.MeasuringHistory" />
    /// </summary>
    public class MeasuringHistoryVm
    {
        public double Measuring { get; set; }

        public int ProductionOrderId { get; set; }
        public int ProductId { get; set; }
        public string DbUserId { get; set; }
        public int MeasuringToolId { get; set; }
        public int ProductStepDimensionId { get; set; }
        public int ProductionStepId { get; set; }
        public ProductionStep ProductionStep { get; set; }
    }
}
