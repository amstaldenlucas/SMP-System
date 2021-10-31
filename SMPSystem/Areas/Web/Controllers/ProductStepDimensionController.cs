using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMPSystem.Areas.Web.Handlers;
using SMPSystem.Areas.Web.ViewModels;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class ProductStepDimensionController : Controller
    {
        private readonly ProductStepDimensionHandler _productStepDimensionHandler;

        public ProductStepDimensionController(ProductStepDimensionHandler productStepDimensionHandler)
        {
            _productStepDimensionHandler = productStepDimensionHandler;
        }

        public IActionResult Index()
        {
            var vm = _productStepDimensionHandler.PrepareVm(new ProductStepDimensionVm());
            return View(vm);
        }

        public async Task<IActionResult> Crate(ProductStepDimensionVm vm)
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
