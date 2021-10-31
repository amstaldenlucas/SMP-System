using AutoMapper;
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
    public class GroupController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly GroupHandler _groupHandler;
        

        public GroupController(AppDbContext dbContext, IMapper mapper, GroupHandler groupHandler)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _groupHandler = groupHandler;
        }

        public async Task<IActionResult> Index()
        {
            var groups = await _dbContext.ProductGroups
                .Where(x => !x.Deleted)
                .ToArrayAsync();
            
            return View(groups);
        }

        public IActionResult Create()
        {
            return View(new ProductGroup());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductGroup group)
        {
            await _groupHandler.Create(group);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupHandler.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
