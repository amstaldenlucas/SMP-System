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
    public class ProductProductionStepsHandler
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductProductionStepsHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductProductionStepsVm> PrepareVm(ProductProductionStepsVm vm)
        {
            var products = await _dbContext.Products
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var productOptions = new List<SelectListItem>() { new SelectListItem("Selecionar Produto", "0") };
            foreach (var item in products)
                productOptions.Add(new SelectListItem(item.Name, item.Id.ToString()));


            var productionSteps = await _dbContext.ProductionSteps
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var productionStepOptions = new List<SelectListItem>() { new SelectListItem("Selecionar Operação", "0") };
            foreach (var item in productionSteps)
                productionStepOptions.Add(new SelectListItem(item.Description, item.Id.ToString()));

            vm.ProductOptions = productOptions;
            vm.ProductionStepOptions = productionStepOptions;
            return vm;
        }

        public async Task Create(ProductProductionStepsVm vm)
        {
            var productProductionStep = _mapper.Map<ProductProductionSteps>(vm);
            var result = await _dbContext.AddAsync(productProductionStep);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int productProductionStepId)
        {
            var prodProductionStep = await _dbContext.ProductProductionSteps.FindAsync(productProductionStepId);
            prodProductionStep.Deleted = true;

            _dbContext.Add(prodProductionStep);
            await _dbContext.SaveChangesAsync();
        }
    }
}
