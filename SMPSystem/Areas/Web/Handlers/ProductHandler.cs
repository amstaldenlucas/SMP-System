using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.Handlers.HandleResults;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Handlers
{
    public class ProductHandler
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductVm> PrepareVm(ProductVm vm)
        {
            var provides = await _dbContext.Providers
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var groups = await _dbContext.ProductGroups
                .Where(x => !x.Deleted).ToArrayAsync();

            var subGroups = await _dbContext.ProductSubGroups
                .Where(x => !x.Deleted)
                .ToArrayAsync();


            var providerOption = new List<SelectListItem>() { new SelectListItem("Selecionar Fabricante", "0") };
            foreach (var item in provides)
                providerOption.Add(new SelectListItem(item.Name, item.Id.ToString()));

            var groupOption = new List<SelectListItem>() { new SelectListItem("Selecionar Grupo", "0") };
            foreach (var item in groups)
                groupOption.Add(new SelectListItem(item.Name, item.Id.ToString()));

            var subGroupOption = new List<SelectListItem>() { new SelectListItem("Selecionar Subgrupo", "0") };
            foreach (var item in subGroups)
                subGroupOption.Add(new SelectListItem(item.Name, item.Id.ToString()));

            vm.Providers = providerOption;
            vm.Groups = groupOption;
            vm.SubGroups = subGroupOption;
            return vm;
        }

        public PrepareResult PrepareInsert(ProductVm vm)
        {
            var result = new PrepareResult();

            if (!string.IsNullOrWhiteSpace(vm.Code))
                result.AddError(nameof(vm.Code),
                    "Informar código do produto");

            if (!string.IsNullOrWhiteSpace(vm.Name))
                result.AddError(nameof(vm.Name),
                    "Informar nome do produto");

            return result;
        }

        public async Task Create(ProductVm vm)
        {
            var product = _mapper.Map<Product>(vm);
            var result = await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
