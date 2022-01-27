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
        //GET
        public async Task <IActionResult> Index()
        {
            List<FridgeViewModel> fridges = await _context.Fridges
                .Select(c => new FridgeViewModel { Id = c.Id, Name = c.Name, Model = c.FridgeModel.Name })
                .ToListAsync();

            return View(fridges);
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
