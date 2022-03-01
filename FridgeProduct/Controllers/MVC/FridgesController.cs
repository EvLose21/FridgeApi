using AutoMapper;
using FridgeProduct.Contracts;
using FridgeProduct.Entities;
using FridgeProduct.Entities.DataTransferObjects;
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
    public class FridgesController : Controller
    {
        RepositoryContext _context;
        public FridgesController(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ModelSortParm"] = sortOrder == "Model" ? "model_desc" : "Model";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var fridges = _context.Fridges
               .Select(c => new FridgeViewModel 
               { 
                   Id = c.Id, 
                   Name = c.Name, 
                   Model = c.FridgeModel.Name 
               });

            if (!String.IsNullOrEmpty(searchString))
            {
                fridges = fridges.Where(
                    f=>f.Name.Contains(searchString)
                    || f.Model.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    fridges = fridges.OrderByDescending(f=>f.Name);
                    break;
                case "Model":
                    fridges = fridges.OrderBy(f => f.Model);
                    break;
                case "model_desc":
                    fridges = fridges.OrderByDescending(f => f.Model);
                    break;
                default:
                    fridges = fridges.OrderBy(f => f.Name);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<FridgeViewModel>.CreateAsync(fridges.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> Details(string sortOrder, Guid? id, string currentFilter, string searchString, int? pageNumber)
        {
            if (id != null)
            {
                ViewData["CurrentSort"] = sortOrder;
                if (searchString != null)
                {
                    pageNumber = 1;
                }
                else
                {
                    searchString = currentFilter;
                }
                ViewData["CurrentFilter"] = searchString;
                var products = _context.FridgeToProducts
                .Where(fp => fp.FridgeId == id)
                .Select(fp => new ProductViewModel
                {
                    Id = fp.ProductId,
                    Name = fp.Product.Name,
                    DefaultQuantity = fp.Quantity
                });
                int pageSize = 3;
                return View(await PaginatedList<ProductViewModel>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Fridge fridge)
        {
            _context.Fridges.Add(fridge);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id != null)
            {
                FridgeViewModel fridgeViewModel = new FridgeViewModel();
                Fridge fridge = await _context.Fridges.FirstOrDefaultAsync(p => p.Id == id);
                if (fridge != null)
                    return View(fridge);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Fridge fridge)
        {
            _context.Fridges.Update(fridge);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(Guid? id)
        {
            if (id != null)
            {
                Fridge fridge = await _context.Fridges.FirstOrDefaultAsync(f => f.Id == id);
                if (fridge != null)
                    return View(fridge);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                Fridge fridge = await _context.Fridges.FirstOrDefaultAsync(f => f.Id == id);
                if (fridge != null)
                {
                    _context.Fridges.Remove(fridge);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }


    }
}
