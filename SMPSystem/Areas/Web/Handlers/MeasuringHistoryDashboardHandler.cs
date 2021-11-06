using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using SMPSystem.Models.TextDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Handlers
{
    public class MeasuringHistoryDashboardHandler
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public MeasuringHistoryDashboardHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDashboardVm> PrepareVm(ProductDashboardVm vm)
        {
            var products = await _dbContext.Products
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var productionSteps = await _dbContext.ProductionSteps
                .ToArrayAsync();

            var productOptions = new List<SelectListItem>() { new SelectListItem("Selecionar Produto", "0") };
            foreach (var item in products)
                productOptions.Add(new SelectListItem(item.Name, item.Id.ToString()));

            var productionStepOptions = new List<SelectListItem>() { new SelectListItem("Selecionar Operação", "0") };
            foreach (var item in productionSteps)
                productionStepOptions.Add(new SelectListItem(item.Code + " - " + item.Name, item.Id.ToString()));

            vm.ProductOptions = productOptions;
            vm.ProductionStepOptions = productionStepOptions;

            if (vm.ProductId > 0)
            {
                var productStepDimension = await _dbContext.ProductStepDimensions
                    .Where(x => x.ProductId == vm.ProductId)
                    .ToArrayAsync();

                var productStepDimensionsOption = new List<SelectListItem>() { new SelectListItem("Selecionar Cota", "0") };
                foreach (var item in productStepDimension)
                    productStepDimensionsOption.Add(new SelectListItem(MeasuringDimensionType.TypeNameDescription(item.MeasuringDimensionType), item.Id.ToString()));

                vm.ProductStepDimensions = productStepDimensionsOption;
            }
            return vm;
        }
    }
}
