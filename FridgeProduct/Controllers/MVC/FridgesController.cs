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
        private readonly IFridgeService _service;
        public FridgesController(IRepositoryManager repostitory, ILoggerManager logger, IMapper mapper, RepositoryContext context, IFridgeService service)
        {
            _repostitory = repostitory;
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            var fridges = await _service.GetFridgeListAsync(pageNumber);
            return View(fridges);
        }

        /*public async Task<IActionResult> Details(Guid? id, int? pageNumber)
        {
            if (id != null)
            {
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
        }*/
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateFridgeModel model = new CreateFridgeModel()
            {
                ModelsList = await _service.InitModelsList(),
                AvailableProducts = await _service.InitProductsList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFridgeModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ModelsList = await _service.InitModelsList();
                model.AvailableProducts = await _service.InitProductsList();
                return View(model);
            }

            await _service.CreateFridgeAsync(model);

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
