using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Models
{
    public class OrderProductStep
    {
        public OrderProductStep()
        {
        }
        public OrderProductStep(int orderId, int productId, int executionOrder)
        {
            OrderId = orderId;
            ProductId = productId;
            ExecutionOrder = executionOrder;
        }

        // operaçõe da ordem.. Assim que cria o pedido já deve popular os registros.
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public int InitialQuantity { get; set; }
        public int ProducedQuantity { get; set; }
        public int LostQuantity { get; set; }
        public bool FinalizedStatus { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ExecutionOrder { get; set; }

        public int ProductProductionStepId { get; set; }
        public ProductProductionStep ProductProductionStep { get; set; }

    }
}
