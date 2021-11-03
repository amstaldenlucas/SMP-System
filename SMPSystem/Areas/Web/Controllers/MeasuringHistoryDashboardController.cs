using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public MeasuringHistoryDashboardController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var measureHistories = await _dbContext.MeasuringHistories
                .Where(x => x.ProductStepDimensionId == 1)
                .ToArrayAsync();
            return View(measureHistories);
        }
    }
}
