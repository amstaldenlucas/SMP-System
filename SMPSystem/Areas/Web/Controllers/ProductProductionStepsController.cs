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
    public class ProductProductionStepsController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ProductProductionStepsHandler _productProductionStepsHandler;

        public ProductProductionStepsController(AppDbContext dbContext, ProductProductionStepsHandler productProductionStepsHandler)
        {
            _dbContext = dbContext;
            _productProductionStepsHandler = productProductionStepsHandler;
        }

        public IActionResult Index()
        {
            var itens = _dbContext.ProductProductionSteps
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            return View(itens);
        }

        public async Task<IActionResult> Create()
        {
            var vm = new ProductProductionStepsVm();
            await _productProductionStepsHandler.PrepareVm(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductProductionStepsVm vm)
        {
            await _productProductionStepsHandler.Create(vm);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productProductionStepsHandler.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
