using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using SMPSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Handlers
{
    public class SubgroupHandler
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubgroupHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SubgroupVm> PrepareVm(SubgroupVm vm)
        {
            var groups = await _dbContext.ProductGroups
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var groupOptions = new List<SelectListItem>() { new SelectListItem("Selecionar Grupo", "0") };
            foreach (var item in groups)
                groupOptions.Add(new SelectListItem(item.Name, item.Id.ToString()));

            vm.Groups = groupOptions;
            return vm;
        }


        public async Task Create(ProductSubGroup subGroup)
        {
            var result = await _dbContext.AddAsync(subGroup);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int subgroupId)
        {
            var provider = await _dbContext.ProductSubGroups.FindAsync(subgroupId);
            _dbContext.Remove(provider);
            await _dbContext.SaveChangesAsync();
        }
    }
}
