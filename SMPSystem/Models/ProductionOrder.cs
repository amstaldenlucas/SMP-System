using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Models
{
    public class ProductionOrder
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime PrevisionDate { get; set; }
        public bool FinalizedStatus { get; set; }
        public int TotalQuantity { get; set; }
        public int ProducedQuantity { get; set; }
        public int LostQuantity { get; set; }

        public int DbUserId { get; set; }
        public DbUser DbUser { get; set; }



    }
}
