using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.Handlers;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ProductHandler _productHandler;

        public ProductController(AppDbContext dbContext, IMapper mapper, ProductHandler productHandler)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _productHandler = productHandler;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _dbContext.Products
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var vm = _mapper.Map<List<ProductVm>>(products);
            return View(vm);
        }


        public async Task<IActionResult> Create()
        {
            var vm = await _productHandler.PrepareVm(new ProductVm());
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductVm vm)
        {
            var prepareResult = _productHandler.PrepareInsert(vm);
            if (prepareResult.HasErrors)
            {
                foreach (var error in prepareResult.Errors)
                    ModelState.AddModelError(error.Key, error.Message);
            }
            if (!ModelState.IsValid)
                return View(vm);

            await _productHandler.Create(vm);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _productHandler.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
