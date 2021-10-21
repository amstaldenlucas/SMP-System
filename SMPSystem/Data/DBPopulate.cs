using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Data
{
    public class DBPopulate
    {
        private readonly AppDbContext _dbContext;

        public DBPopulate(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task VerifyAndPopulateDb()
        {
            if (_dbContext.DbUsers.Any()) return;

            await CreateProviders();
            await CreateProducs();
        }

        private async Task CreateProviders()
        {
            _dbContext.AddRange(new List<Provider>()
            {
                new Provider() { Name = "Fornecedor 1 LTDA", TradingName = "Fornecedor 1", Document = "17.195.835/0001-47" },
                new Provider() { Name = "Fornecedor 2 LTDA", TradingName = "Fornecedor 2", Document = "47.788.718/0001-58" },
            });
            await _dbContext.SaveChangesAsync();
        }

        private async Task CreateProducs()
        {
            var providers = await _dbContext.Providers.ToArrayAsync();
            _dbContext.AddRange(new List<Product>()
            {
                new Product() { Code = "12345", Name = "Produto 1", ProviderId = providers.FirstOrDefault(x => x.TradingName == "Fornecedor 1").Id.ToString()},
                new Product() { Code = "67890", Name = "Produto 2", ProviderId = providers.FirstOrDefault(x => x.TradingName == "Fornecedor 2").Id.ToString()},
            });
            _dbContext.SaveChangesAsync();
        }
    }
}