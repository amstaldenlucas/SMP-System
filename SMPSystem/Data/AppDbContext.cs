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
    }
}
