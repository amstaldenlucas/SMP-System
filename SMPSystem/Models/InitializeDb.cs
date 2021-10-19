using SMPSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Models
{
    public static class InitializeDb
    {
        public static void Initialize(AppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
