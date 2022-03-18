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
        public FridgesController(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
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
            FridgeCreateViewModel fridgeCreateViewModel = new FridgeCreateViewModel();
            //Models List
            fridgeCreateViewModel.ModelsList = _context.FridgeModels.Select(x => new SelectListItem { 
                Value = x.Id.ToString(), 
                Text = x.Name,
            }).ToList();
            //Products List
            fridgeCreateViewModel.Products = _context.Products.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            Console.WriteLine(fridgeCreateViewModel.ModelsList);
            return View(fridgeCreateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FridgeCreateViewModel fridgeCreateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Fridge fridge = new Fridge()
                    {
                        Name = fridgeCreateViewModel.Name,
                        FridgeModelId = fridgeCreateViewModel.ModelId,
                        Description = fridgeCreateViewModel.Description
                    };


                    /*for (int i = 0; i < fridgeCreateViewModel.SelectedProducts.Count; i++)
                    {
                        FridgeToProduct fProduct = new FridgeToProduct()
                        {
                            FridgeId = fridge.Id,
                            ProductId = fridgeCreateViewModel.SelectedProducts[i]
                        };
                        _context.Add(fProduct);
                    }*/
                    try
                    {
                        _context.Add(fridge);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(fridgeCreateViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id != null)
            {
                FridgeUpdateViewModel fridgeUpdateViewModel = new FridgeUpdateViewModel();
                Fridge fridge = await _context.Fridges.FirstOrDefaultAsync(p => p.Id == id);
                fridge.Name = fridgeUpdateViewModel.Name;
                fridge.Description = fridgeUpdateViewModel.Description;
                await _context.SaveChangesAsync();
                return View(fridgeUpdateViewModel);
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
        }

    }
}
