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
    public class FridgesController : Controller
    {
        RepositoryContext _context;
        private readonly IRepositoryManager _repostitory;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IFridgeService _fridgeService;
        private readonly IProductService _productService;
        public FridgesController(IRepositoryManager repostitory, ILoggerManager logger, IMapper mapper, RepositoryContext context, IFridgeService fridgeService, IProductService productService)
        {
            _repostitory = repostitory;
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _fridgeService = fridgeService;
            _productService = productService;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            var fridges = await _fridgeService.GetFridgeListAsync(pageNumber);
            return View(fridges);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid? id, int? pageNumber)
        {
            if (id != null)
            {
                var productsByFridge = await _productService.ProductsByFridgeAsync(id, pageNumber);
                return View(productsByFridge);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            FridgeCreateViewModel model1 = new FridgeCreateViewModel()
            {
                ModelsList = await _fridgeService.GetFridgeModels(),
                AvailableProducts = await _fridgeService.GetProductNames()
            };

            return View(model1);
        }

        [HttpPost]
        
        public async Task<IActionResult> Create(FridgeCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ModelsList = await _fridgeService.GetFridgeModels();
                model.AvailableProducts = await _fridgeService.GetProductNames();
                return View(model);
            }

            
            await _fridgeService.CreateFridgeAsync(model.FridgeParameters);

            return RedirectToAction(nameof(Index));
        }

        /*public async Task<IActionResult> Edit(Guid? id)
        {
            if (id != null)
            {
                Fridge fridge = await _context.Fridges.FirstOrDefaultAsync(p => p.Id == id);
                FridgeUpdateViewModel model = new FridgeUpdateViewModel()
                {
                    Name = fridge.Name,
                    Description = fridge.Description,
                    OwnerName = fridge.OwnerName
                };
                
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FridgeUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Fridge fridge = await _context.Fridges.FirstOrDefaultAsync(p => p.Id == model.Id);
                fridge.Name = model.Name;
                fridge.Description = model.Description;
                fridge.OwnerName = model.OwnerName;

                _context.Fridges.Update(fridge);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
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

        public IActionResult AddProduct(Guid? id)
        {
            if (id != null)
            {
                var fProducts = _context.FridgeToProducts.ToList();
                ViewBag.FridgeProducts = new SelectList(fProducts, "FridgeId", "ProductId", "Quantity");
                return View();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Guid? id, FridgeToProduct fProduct)
        {
            if (id != null)
            {
                fProduct = new FridgeToProduct
                {
                    ProductId = fProduct.ProductId,
                    Quantity = fProduct.Quantity,
                    FridgeId = (Guid)id
                };
                _context.FridgeToProducts.Add(fProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details");
            }

            return NotFound();
        }*/

    }
}
