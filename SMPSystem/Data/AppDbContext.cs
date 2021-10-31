using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMPSystem.Data
{
    public class AppDbContext : IdentityDbContext<DbUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<DbUser> DbUsers { get; set; }

        public DbSet<MeasuringTool> MeasuringTools { get; set; }
        public DbSet<MeasuringToolConference> MeasuringToolConference { get; set; }
        public DbSet<MeasuringHistory> measuringHistories { get; set; }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductSubGroup> ProductSubGroups { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<ProductionStep> ProductionSteps { get; set; }
        public DbSet<ProductStepDimension> ProductStepDimensions { get; set; }
        public DbSet<ProductProductionStep> ProductProductionSteps { get; set; }
        public DbSet<OrderProductStep> OrderProductSteps{ get; set; }

        public DbSet<UserProductionHistory> UserProductionHistories { get; set; }
    }
}
