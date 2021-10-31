using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.Handlers;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class ProductionOrderController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ProductionOrderHandler _productionOrderHandler;

        public ProductionOrderController(AppDbContext dbContext, ProductionOrderHandler productionOrderHandler)
        {
            _dbContext = dbContext;
            _productionOrderHandler = productionOrderHandler;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _dbContext.ProductionOrders.ToArrayAsync();
            return View(orders);
        }

        public async Task<IActionResult> Create()
        {
            var vm = await _productionOrderHandler.PrepareVm(new ProductionOrderVm());
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductionOrderVm vm)
        {
            await _productionOrderHandler.Create(vm);
            return RedirectToAction(nameof(Index));
        }
    }
}
