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
    public class ProviderController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProviderController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var provides = await _dbContext.Providers
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            return View(provides);
        }

        public IActionResult Create()
        {
            return View(new Provider());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Provider provider)
        {
            var result = await _dbContext.AddAsync(provider);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
