using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class RrecordMeasureController : Controller
    {
        private readonly AppDbContext _dbContext;

        public RrecordMeasureController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Record(UserProducingVm vm)
        {
            var measures = vm.MeasuringHistories;
            foreach (var item in measures)
                await _dbContext.AddAsync(item);

            await _dbContext.SaveChangesAsync();
            return RedirectToAction("SumQuantity", "UserProductionHistory", vm);
        }
    }
}
