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
    public class MeasuringToolController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly MeasuringToolHandler _measuringToolHandler;

        public MeasuringToolController(AppDbContext dbContext, MeasuringToolHandler measuringToolHandler)
        {
            _dbContext = dbContext;
            _measuringToolHandler = measuringToolHandler;
        }

        public async Task<IActionResult> Index()
        {
            var measuringTools = await _dbContext.MeasuringTools
                .Where(x => !x.Deleted)
                .ToArrayAsync();
            return View(measuringTools);
        }

        public IActionResult Create()
        {
            var vm = _measuringToolHandler.PrepareVm(new MeasuringToolVm());
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MeasuringToolVm vm)
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
