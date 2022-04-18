using AutoMapper;
using FridgeProduct.BusinessLayer.Interfaces;
using FridgeProduct.BusinessLayer.Models;
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
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            var products = await _service.GetProductListAsync(pageNumber);
            return View(products);
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
                var product = _mapper.Map<CreateProductModel>(model);

                if (product.ProductType.Equals("exist"))
                {
                    ModelState.AddModelError("Name", $"{model.Name} already exist");
                    return View(model);
                }

                var addedProduct = await _service.CreateProductAsync(product);

                /*if (product.ProductType.ToString().Equals("exist"))
                {
                    ModelState.AddModelError("Name", $"{model.Name} уже существует");
                    return View(model);
                }

                if (product.ProductType.ToString().Equals("over"))
                {
                    ModelState.AddModelError("Name", $"{model.Name} более 100");
                    return View(model);
                }*/

                /*if (addedProduct == Guid.Empty)
                {
                    ModelState.AddModelError("Name", $"{model.Name} already exist");
                    return View(model);
                }*/

                return RedirectToAction(nameof(Index));

            }

            return View(model);
        }

        /*public async Task<IActionResult> Edit(Guid? id)
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
        }*/
    }
}
