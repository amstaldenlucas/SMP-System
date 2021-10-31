using AutoMapper;
using SMPSystem.Data;
using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Handlers
{
    public class ProviderHandler
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProviderHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Create(Provider provider)
        {
            var result = await _dbContext.AddAsync(provider);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int providerId)
        {
            var provider = await _dbContext.Providers.FindAsync(providerId);
            _dbContext.Remove(provider);
            await _dbContext.SaveChangesAsync();
        }
    }
}
