using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Data;
using SMPSystem.Models;
using System.Collections.Generic;
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

        public GroupController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            var result = await _dbContext.AddAsync(group);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
