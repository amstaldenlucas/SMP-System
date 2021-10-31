using AutoMapper;
using SMPSystem.Data;
using SMPSystem.Models;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Handlers
{
    public class GroupHandler
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GroupHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Create(ProductGroup group)
        {
            var result = await _dbContext.AddAsync(group);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int groupId)
        {
            var group = await _dbContext.ProductGroups.FindAsync(groupId);
            _dbContext.Remove(group);
            await _dbContext.SaveChangesAsync();
        }
    }
}
