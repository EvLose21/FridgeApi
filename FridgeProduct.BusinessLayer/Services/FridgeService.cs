using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public FridgeService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
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

        public async Task<List<SelectListItem>> GetFridgeModels()
        {
            var ModelsList = await _repositoryManager.FridgeModel.GetAllFridgeModelsQuery(trackChanges:false)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToListAsync();

            return ModelsList;
        }

        public async Task<List<SelectListItem>> GetProductNames()
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
            
            if (model.ModelId.ToString() == null)
            { 
                throw new ArgumentNullException("Fridge model cannot be found"); 
            }

            var addedFridge = new Fridge
            {
                Name = model.Name,
                Description = model.Description,
                FridgeModelId = model.ModelId
            };

            _repositoryManager.Fridge.Create(addedFridge);
            await _repositoryManager.SaveAsync();

            if (model.SelectedProducts != null && model.SelectedProducts.Count() > 0)
            {
                for (int i = 0; i < model.SelectedProducts.Count(); i++)
                {
                    FridgeToProduct fProduct = new FridgeToProduct()
                    {
                        FridgeId = addedFridge.Id,
                        ProductId = model.SelectedProducts[i]
                    };

                    _repositoryManager.FridgeToProduct.AddProductForFridge(fProduct);
                }
            }

            await _repositoryManager.SaveAsync();

            return addedFridge.Id;
        }

        public async void DeleteFridge(Guid id)
        {
            await _repositoryManager.Fridge.FindByCondition(f => f.Id.Equals(id), trackChanges: false)
            .SingleOrDefaultAsync();
        }
    }
}
