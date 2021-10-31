using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.Handlers;
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
        private readonly ProviderHandler _providerHandler;

        public ProviderController(AppDbContext dbContext, IMapper mapper, ProviderHandler providerHandler)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _providerHandler = providerHandler;
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
            await _providerHandler.Create(provider);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _providerHandler.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
