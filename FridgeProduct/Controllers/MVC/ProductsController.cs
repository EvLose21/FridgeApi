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

        //GET
        //посмотреть в консоли запросы

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 3;   // количество элементов на странице

            IQueryable<ProductViewModel> source = _context.Products
                .Select(c => new ProductViewModel { 
                    Id = c.Id, 
                    Name = c.Name, 
                    DefaultQuantity = c.DefaultQuantity 
                });
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            {
                IndexProductViewModel viewModel = new IndexProductViewModel
                {
                    PageViewModel = pageViewModel,
                    Products = items
                };
                return View(viewModel);
            }
        }
        /*
        //POST
        public IActionResult Upadte()
        {
            return View();
        }*/

        public IActionResult Create()
        {
            var products = _context.Products.ToList();
            ViewBag.Products = new SelectList(products, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id != null)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
