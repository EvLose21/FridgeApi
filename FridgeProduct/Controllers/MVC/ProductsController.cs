using AutoMapper;
using FridgeProduct.Contracts;
using FridgeProduct.Entities;
using FridgeProduct.Entities.Models;
using FridgeProduct.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeProduct.Controllers.MVC
{
    public class ProductsController : Controller
    {
        RepositoryContext _context;
        public ProductsController(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            var products = _context.Products
               .Select(p => new ProductViewModel
               {
                   Id = p.Id,
                   Name = p.Name,
                   DefaultQuantity = p.DefaultQuantity
               });

            int pageSize = 3;
            return View(await PaginatedList<ProductViewModel>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public IActionResult Create()
        {
            ProductCreateViewModel model = new ProductCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    Name = model.Name,
                    DefaultQuantity = model.DefaultQuantity
                };
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id != null)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                ProductUpdateViewModel model = new ProductUpdateViewModel()
                {
                    Name = product.Name,
                    DefaultQuantity = product.DefaultQuantity
                };

                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == model.Id);
                product.Name = model.Name;
                product.DefaultQuantity = model.DefaultQuantity;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
