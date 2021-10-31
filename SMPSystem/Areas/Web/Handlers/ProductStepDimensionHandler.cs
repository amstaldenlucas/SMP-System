using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.Models;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using SMPSystem.Models;
using SMPSystem.Models.TextDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Handlers
{
    public class ProductStepDimensionHandler
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductStepDimensionHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductStepDimensionVm> PrepareVm(ProductStepDimensionVm vm)
        {
            DefineMeasuringDimensionOptions(vm);
            DefineMeasuringToolOptions(vm);
            await DefineProductOptions(vm);
            await DefineProductionStepOptions(vm);

            return vm;
        }

        public async Task Create(ProductStepDimensionVm vm)
        {
            var productStepDimension = _mapper.Map<ProductStepDimension>(vm);
            var result = await _dbContext.AddAsync(productStepDimension);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int productStepDimensionId)
        {
            var productStepDimension = await _dbContext.ProductStepDimensions.FindAsync(productStepDimensionId);
            productStepDimension.Deleted = true;
            await _dbContext.AddAsync(productStepDimensionId);
            await _dbContext.SaveChangesAsync();
        }

        private void DefineMeasuringToolOptions(ProductStepDimensionVm vm)
        {
            var list = Enum.GetValues(typeof(MeasuringToolTypeOption));
            var measuringOption = new List<SelectListItem>();
            foreach (var item in list)
            {
                var text = MeasuringToolType.TypeNameDescription(item.ToString());
                measuringOption.Add(new SelectListItem(text, item.ToString()));
            }

            vm.MeasuringToolTypeOptions = measuringOption;
        }
        
        private void DefineMeasuringDimensionOptions(ProductStepDimensionVm vm)
        {
            var list = Enum.GetValues(typeof(MeasuringDimensionTypeOption));
            var measuringDimensionOption = new List<SelectListItem>();
            foreach (var item in list)
            {
                var text = MeasuringDimensionType.TypeNameDescription(item.ToString());
                measuringDimensionOption.Add(new SelectListItem(text, item.ToString()));
            }

            vm.DimensionTypeOptions = measuringDimensionOption;
        }

        private async Task DefineProductOptions(ProductStepDimensionVm vm)
        {
            var products = await _dbContext.Products
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var productOptions = new List<SelectListItem>() { new SelectListItem("Selecionar Produto", "0") };
            foreach (var item in products)
                productOptions.Add(new SelectListItem(item.Name, item.Id.ToString()));

            vm.ProductOptions = productOptions;
        }
        private async Task DefineProductionStepOptions(ProductStepDimensionVm vm)
        {
            var availableProductionStepByProduct = await _dbContext.ProductProductionSteps
               .Where(x => !x.Deleted)
               .Where(x => x.ProductId == vm.ProductId)
               .Select(x => x.ProductionStepId)
               .ToListAsync();

            var productionSteps = _dbContext.ProductionSteps
                .Where(x => !x.Deleted);

            if (vm.ProductId > 0)
                productionSteps = productionSteps.Where(x => availableProductionStepByProduct.Contains(x.Id));

            var productionStepOptions = new List<SelectListItem>() { new SelectListItem("Selecionar operação", "0") };
            foreach (var item in productionSteps)
                productionStepOptions.Add(new SelectListItem(item.Description, item.Id.ToString()));

            vm.ProductionStepOptions = productionStepOptions;
        }
    }
}
