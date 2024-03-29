﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SMPSystem.Models
{
    public class UserProductionHistory
    {
        public int Id { get; set; }
        public string DbUserId { get; set; }
        public DbUser DbUser { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public int ProductionOrderId { get; set; }
        public ProductionOrder productionOrder { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductionStepId { get; set; }
        public ProductionStep ProductionStep { get; set; }

        // true para ordem rodando
        public bool Status { get; set; }
        [Display (Name = "Quantidade Produzida")]
        public int ProducedQuantity { get; set; }
    }
}
