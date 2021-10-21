using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SMPSystem.Data;
using SMPSystem.Models;
using System;
using System.Threading.Tasks;

namespace SMPSystem.Services
{
    public static class InitializeDb
    {
        public static void Initialize(AppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            _ = PopulateDb(dbContext);
        }

        public static string GetStringConnection()
        {
            var computerName = Environment.MachineName;
            return computerName switch
            {
                "DESKTOP-AVJKKN2" => "SQLServerConnectionHome",
                "DESKTOP-0V1JOMM" => "SQLServerConnectionCNS",
                _ => "DefaultConnection"
            };
        }

        private static async Task PopulateDb(AppDbContext dbContext)
        {
            var dBPopulate = new DBPopulate(dbContext);
            await dBPopulate.VerifyAndPopulateDb();
        }
    }
}
