using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FridgeProduct.BusinessLayer.Interfaces;
using FridgeProduct.BusinessLayer.Models;
using FridgeProduct.Contracts;
using FridgeProduct.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FridgeProduct.BusinessLayer.Services
{
    public class FridgeService : IFridgeService
    {
        private readonly IRepositoryManager _repositoryManager;
        public FridgeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<PaginatedList<FridgeListItem>> GetFridgeListAsync(int? pageNumber)
        {
            var fridges = _repositoryManager.Fridge.GetAllFridgesQuery(trackChanges: false).
                Select(l => new FridgeListItem
                {
                    Id = l.Id,
                    Name = l.Name,
                    Model = l.FridgeModel.Name
                });

            return await PaginatedList<FridgeListItem>.CreateAsync(fridges, pageNumber??1, 3);
        }

        public async Task<List<SelectListItem>> InitModelsList()
        {
            var ModelsList = await _repositoryManager.FridgeModel.GetAllFridgeModelsQuery(trackChanges:false)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToListAsync();

            return ModelsList;
        }

        public async Task<List<SelectListItem>> InitProductsList()
        {
            var ProductsList = await _repositoryManager.Product.GetAllProductsQuery(trackChanges: false)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToListAsync();

            return ProductsList;
        }

        public async Task<Guid> CreateFridgeAsync(CreateFridgeModel model)
        {
            if(model == null) throw new ArgumentNullException(nameof(model));

            CreateFridgeParameter parameter = new CreateFridgeParameter()
            {
                Name = model.Name,
                Description = model.Description,
                ModelId = model.ModelId,
                Products = model.SelectedProducts
            };

            return await _repositoryManager.Fridge.CreateAsync(parameter);
        }
    }
}
