using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMPSystem.Areas.Web.ViewModels;
using SMPSystem.Data;
using SMPSystem.Models;
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

        public ProductController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _dbContext.Products.ToArrayAsync();
            var vm = _mapper.Map<List<ProductVm>>(products);

            return View(vm);
        }


        public async Task<IActionResult> Create()
        {
            var provides = await _dbContext.Providers
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var groups = await _dbContext.ProductGroups
                .Where(x => !x.Deleted)
                .ToArrayAsync();

            var subGroups = await _dbContext.ProductSubGroups
                .Where(x => !x.Deleted)
                .ToArrayAsync();


            var providerOption = new List<SelectListItem>() { new SelectListItem("Selecionar Fabricante", "0") };
            foreach (var item in provides)
                providerOption.Add(new SelectListItem(item.Name, item.Id.ToString()));

            var groupOption = new List<SelectListItem>() { new SelectListItem("Selecionar Grupo", "0") };
            foreach (var item in groups)
                groupOption.Add(new SelectListItem(item.Name, item.Id.ToString()));

            var subGroupOption = new List<SelectListItem>() { new SelectListItem("Selecionar Subgrupo", "0") };
            foreach (var item in subGroups)
                subGroupOption.Add(new SelectListItem(item.Name, item.Id.ToString()));

            return View(new ProductVm(providerOption, groupOption, subGroupOption));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                var result = await _dbContext.AddAsync(product);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
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
    }
}
