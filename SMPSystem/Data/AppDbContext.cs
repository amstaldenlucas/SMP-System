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

        public DbSet<MeasuringInstrumentType> MeasuringInstrumentTypes { get; set; }
        public DbSet<MeasuringInstrument> MeasuringInstruments { get; set; }
        public DbSet<MeasuringInstrumentConference> MeasuringInstrumentConferences { get; set; }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductSubGroup> ProductSubGroups { get; set; }
    }
}
