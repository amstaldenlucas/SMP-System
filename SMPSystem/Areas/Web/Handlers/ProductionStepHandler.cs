using AutoMapper;
using SMPSystem.Data;
using SMPSystem.Models;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Handlers
{
    public class ProductionStepHandler
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductionStepHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Create(ProductionStep productionStep)
        {
            var result = await _dbContext.AddAsync(productionStep);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int productionStepId)
        {
            var productionStep = await _dbContext.ProductionSteps.FindAsync(productionStepId);
            productionStep.Deleted = true;

            _dbContext.Add(productionStep);
            await _dbContext.SaveChangesAsync();
        }
    }
}
