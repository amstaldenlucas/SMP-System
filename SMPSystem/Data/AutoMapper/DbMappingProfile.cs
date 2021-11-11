using AutoMapper;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Models;

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

            CreateMap<ProductProductionStep, ProductProductionStepsVm>()
                .ReverseMap();

            CreateMap<ProductStepDimension, ProductStepDimensionVm>()
                .ReverseMap();

            CreateMap<MeasuringTool, MeasuringToolVm>()
                .ReverseMap();

            CreateMap<ProductionOrder, ProductionOrderVm>()
                .ReverseMap();
        }

        private Provider GetProviderById(int? providerId = 0)
            => _dbContext.Providers.Find(providerId);
    }
}
