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
    public class ProductionOrderHandler
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductionOrderHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductionOrderVm> PrepareVm(ProductionOrderVm vm)
        {
            var users = await _dbContext.DbUsers
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var products = await _dbContext.Products
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var userOptions = new List<SelectListItem>() { new SelectListItem("Selecionar Usuário PCP", "0") };
            foreach (var item in users)
                userOptions.Add(new SelectListItem(item.UserName, item.Id));

            var productOptions = new List<SelectListItem>() { new SelectListItem("Selecionar Produto", "0") };
            foreach (var item in products)
                productOptions.Add(new SelectListItem(item.Name, item.Id.ToString()));

            return vm;
        }

        public async Task Create(ProductionOrderVm vm)
        {
            var productionOrder = _mapper.Map<ProductionOrder>(vm);
            var result = await _dbContext.AddAsync(productionOrder);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int orderId)
        {
            var order = await _dbContext.ProductionOrders.FindAsync(orderId);
            order.FinalizedStatus = true;
            order.Obs = "Pedido deletado";
            await _dbContext.SaveChangesAsync();
        }
    }
}
