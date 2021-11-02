using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class OrderOperatorUserController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderOperatorUserController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var availableOrders = await _dbContext.ProductionOrders
                .Where(x => !x.FinalizedStatus)
                .ToArrayAsync();

            return View(availableOrders);
        }

        public async Task<IActionResult> StartProduction()
        {
            var users = await _dbContext.DbUsers
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var userOptions = new List<SelectListItem>() { new SelectListItem("Selecionar operador", "0") };
            foreach (var item in users)
                userOptions.Add(new SelectListItem(item.UserName, item.Id));
            var vm = new OrderWithDbUserVm();
            vm.DbUserOptions = userOptions;

            return View(vm);
        }

        public async Task<IActionResult> SearchProduction(OrderWithDbUserVm vm)
        {
            var orderProduction = await _dbContext.ProductionOrders
                .FirstOrDefaultAsync(x => x.Code == vm.ProductionOrderCode);

            vm.ProductionOrderId = orderProduction.Id;
            var orderProductionItem = await _dbContext.OrderProductSteps
                .Where(x => x.OrderId == orderProduction.Id)
                .Where(x => !x.FinalizedStatus)
                .OrderBy(x => x.ExecutionOrder)
                .FirstOrDefaultAsync();

            var productProductionStep = await _dbContext.ProductProductionSteps
                                                            .FindAsync(orderProductionItem.ProductProductionStepId);
            productProductionStep.Product = await _dbContext.Products
                                                .FindAsync(productProductionStep.ProductId);

            productProductionStep.ProductionStep = await _dbContext.ProductionSteps
                                                .FindAsync(productProductionStep.ProductionStepId);

            orderProductionItem.ProductProductionStep = productProductionStep;

            if (orderProductionItem.InitialQuantity == 0)
                orderProductionItem.InitialQuantity = orderProduction.TotalQuantity;

            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == vm.DbUserId);


            // OrderProductStep.ProductProductionStep.ProductionStep.Code
            // OrderProductStep.ProductProductionStep.Product.Name
            vm.DbUser = user;
            vm.DbUserId = user.Id;
            vm.ProductionOrder = orderProduction;
            vm.OrderProductStep = orderProductionItem;
            //vm.ProductionOrder.OrderProductSteps.Add(orderProductionItem);

            return View(vm);
        }

        public async Task<IActionResult> OperatorProducing(OrderWithDbUserVm vm)
        {
            var order = await _dbContext.ProductionOrders
                .Where(x => x.Id == vm.ProductionOrderId)
                .FirstOrDefaultAsync();
            return View(vm);
        }
    }
}
