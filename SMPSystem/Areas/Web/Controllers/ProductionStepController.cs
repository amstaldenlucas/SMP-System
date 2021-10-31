using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.Handlers;
using SMPSystem.Data;
using SMPSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class ProductionStepController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ProductionStepHandler _productionStepHandler;
        public ProductionStepController(AppDbContext dbContext, ProductionStepHandler productionStepHandler)
        {
            _dbContext = dbContext;
            _productionStepHandler = productionStepHandler;
        }

        public async Task<IActionResult> Index()
        {
            var productStepHandlers = await _dbContext.ProductionSteps
                .Where(x => !x.Deleted)
                .ToArrayAsync();
            return View(productStepHandlers);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductionStep productionStep)
        {
            await _productionStepHandler.Create(productionStep);
            return RedirectToAction(nameof(Index));
        }
    }
}
