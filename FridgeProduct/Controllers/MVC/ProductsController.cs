using AutoMapper;
using FridgeProduct.Contracts;
using FridgeProduct.Entities;
using FridgeProduct.Entities.Models;
using FridgeProduct.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index()
        {
            List<ProductViewModel> fridges = (await _context.Products
                .ToListAsync())
                .Select(c => new ProductViewModel { Id = c.Id, Name = c.Name, DefaultQuantity = c.DefaultQuantity })
                .ToList();

            return View(fridges);
        }
        /*
        //POST
        public IActionResult Upadte()
        {
            return View();
        }*/

        public IActionResult Create()
        {
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
