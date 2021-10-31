using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.Handlers;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using SMPSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class SubgroupController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly SubgroupHandler _subgroupHandler;

        public SubgroupController(AppDbContext dbContext, IMapper mapper, SubgroupHandler subgroupHandler)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _subgroupHandler = subgroupHandler;
        }

        public async Task<IActionResult> Index()
        {
            var subgroups = await _dbContext.ProductSubGroups
                .Where(x => !x.Deleted)
                .Include(x => x.ProductGroup)
                .ToArrayAsync();

            return View(subgroups);
        }

        public async Task<IActionResult> Create()
        {
            var vm = await _subgroupHandler.PrepareVm(new SubgroupVm());
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductSubGroup subGroup)
        {
            await _subgroupHandler.Create(subGroup);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _subgroupHandler.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
