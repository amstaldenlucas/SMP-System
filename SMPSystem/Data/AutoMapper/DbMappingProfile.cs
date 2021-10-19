using AutoMapper;
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

            /* Example */
            //CreateMap<Produto, ProdutoVm>()
            //    .ForMember(x => x.NomeFabricante,
            //        cfg => cfg.MapFrom((md) => GetNomeFabricantePorId(md.FabricanteId)));
        }


        /* Example */
        //private object GetNomeFabricantePorId(string fabricanteId)
        //    => _dbContext.Fabricantes.Find(fabricanteId)?.RazaoSocial;
    }
}
