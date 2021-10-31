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
    public class ProductStepDimensionController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ProductStepDimensionHandler _productStepDimensionHandler;

        public ProductStepDimensionController(AppDbContext dbContext, ProductStepDimensionHandler productStepDimensionHandler)
        {
            _dbContext = dbContext;
            _productStepDimensionHandler = productStepDimensionHandler;
        }

        public async Task<IActionResult> Index()
        {
            var productDimensions = await _dbContext.ProductStepDimensions
                .Where(x => !x.Deleted)
                .Include(x => x.Product)
                .Include(x => x.ProductionStep)
                .ToArrayAsync();
            return View(productDimensions);
        }

        public async Task<IActionResult> Create()
        {
            var vm = await _productStepDimensionHandler.PrepareVm(new ProductStepDimensionVm());
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductStepDimensionVm vm)
        {
            await _productStepDimensionHandler.Create(vm);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productStepDimensionHandler.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
