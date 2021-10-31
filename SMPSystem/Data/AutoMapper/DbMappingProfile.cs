using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Data.AutoMapper
{
    public class DbMappingProfile : Profile
    {
        private readonly AppDbContext _dbContext;

        public DbMappingProfile(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            CreateMap<Product, ProductVm>()
                .ForMember(x => x.Provider,
                    cfg => cfg.MapFrom((md) => GetProviderById(md.ProviderId)))
                .ReverseMap();

            CreateMap<ProductSubGroup, SubgroupVm>()
                .ReverseMap();

            CreateMap<ProductProductionSteps, ProductProductionStepsVm>()
                .ReverseMap();

            CreateMap<ProductStepDimension, ProductStepDimensionVm>()
                .ReverseMap();

            CreateMap<MeasuringTool, MeasuringToolVm>()
                .ReverseMap();
        }

        private Provider GetProviderById(int providerId)
            => _dbContext.Providers.Find(providerId);
    }
}
