using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMPSystem.Areas.Web.Models;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using SMPSystem.Models;
using SMPSystem.Models.TextDefinitions;
using System;
using System.Collections.Generic;
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

        public ProductStepDimensionVm PrepareVm(ProductStepDimensionVm vm)
        {
            var list = Enum.GetValues(typeof(MeasuringToolTypeOption));
            var measuringOption = new List<SelectListItem>();
            foreach (var item in list)
            {
                var text = MeasuringToolType.TypeNameDescription(item.ToString());
                measuringOption.Add(new SelectListItem(text, item.ToString()));
            }

            vm.MeasuringToolTypeOptions = measuringOption;
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
    }
}
