using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMPSystem.Areas.Web.Handlers;
using SMPSystem.Areas.Web.ViewModels;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class MeasuringToolController : Controller
    {
        private readonly MeasuringToolHandler _measuringToolHandler;

        public MeasuringToolController(MeasuringToolHandler measuringTool)
        {
            _measuringToolHandler = measuringTool;
        }

        public IActionResult Index()
        {
            var vm = _measuringToolHandler.PrepareVm(new MeasuringToolVm());
            return View(vm);
        }

        public async Task<IActionResult> Crate(MeasuringToolVm vm)
        {
            await _measuringToolHandler.Create(vm);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _measuringToolHandler.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
