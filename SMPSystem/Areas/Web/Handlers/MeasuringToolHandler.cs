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
    public class MeasuringToolHandler
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public MeasuringToolHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MeasuringToolVm PrepareVm(MeasuringToolVm vm)
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

        public async Task Create(MeasuringToolVm vm)
        {
            var measuringTool = _mapper.Map<MeasuringTool>(vm);
            var result = await _dbContext.AddAsync(measuringTool);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int measuringToolId)
        {
            var measuringTool = await _dbContext.Products.FindAsync(measuringToolId);
            measuringTool.Deleted = true;
            await _dbContext.AddAsync(measuringTool);
            await _dbContext.SaveChangesAsync();
        }
    }
}
