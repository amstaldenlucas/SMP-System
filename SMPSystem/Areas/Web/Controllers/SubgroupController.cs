using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using SMPSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class SubgroupController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubgroupController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            var groups = await _dbContext.ProductGroups
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var groupOptions = new List<SelectListItem>() { new SelectListItem("Selecionar Grupo", "0") };
            foreach (var item in groups)
                groupOptions.Add(new SelectListItem(item.Name, item.Id.ToString()));

            var vm = new SubgroupVm() { Groups = groupOptions };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductSubGroup subGroup)
        {
            var result = await _dbContext.AddAsync(subGroup);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
