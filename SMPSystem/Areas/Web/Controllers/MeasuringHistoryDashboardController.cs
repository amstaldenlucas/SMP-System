using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.Handlers;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class MeasuringHistoryDashboardController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly MeasuringHistoryDashboardHandler _dashboardHandler;

        public MeasuringHistoryDashboardController(AppDbContext dbContext, MeasuringHistoryDashboardHandler dashboardHandler)
        {
            _dbContext = dbContext;
            _dashboardHandler = dashboardHandler;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new ProductDashboardVm();
            await _dashboardHandler.PrepareVm(vm);

            //vm.MeasuringHistories = await _dbContext.MeasuringHistories
            //    .Where(x => x.ProductStepDimensionId == 1)
            //    .ToArrayAsync();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProductDashboardVm vm)
        {
            await _dashboardHandler.PrepareVm(vm);
            var queriable = _dbContext.MeasuringHistories
                .Include(x => x.ProductStepDimension)
                .AsQueryable();

            if (vm.ProductId > 0)
                queriable = queriable.Where(x => x.ProductId == vm.ProductId);

            if (vm.ProductionStepId > 0)
                queriable = queriable.Where(x => x.ProductionStepId == vm.ProductionStepId);

            if (vm.OrderCode > 0)
            {
                var orderId = _dbContext.ProductionOrders.Where(x => x.Code == vm.OrderCode).FirstOrDefault().Id;
                queriable = queriable.Where(x => x.ProductionOrderId == orderId);
            }

            if (vm.ProductStepDimensionId > 0)
            {
                queriable = queriable.Where(x => x.ProductStepDimension.Id == vm.ProductStepDimensionId);
                vm.MeasuringHistories = await queriable.ToListAsync();

                var product = await _dbContext.Products.FindAsync(vm.ProductId);
                vm.ProductName = product?.Name;
            }

            return View(vm);
        }
    }
}
