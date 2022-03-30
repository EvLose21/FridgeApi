using FridgeProduct.Contracts;
using FridgeProduct.Entities;
using FridgeProduct.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Repository
{
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        } 

        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges)=>
            await FindAll(trackChanges)
            .Include(fr=>fr.FridgeModel)
            .Include(fr=>fr.Products)
            .OrderBy(f=>f.Name)
            .ToListAsync();

        public IQueryable<Fridge> GetAllFridgesQuery(bool trackChanges) =>
             FindAll(trackChanges)
            .Include(fr => fr.FridgeModel)
            .Include(fr => fr.Products)
            .OrderBy(f => f.Name);

        public async Task<Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges)=>
            await FindByCondition(f => f.Id.Equals(fridgeId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<Guid> CreateAsync(CreateFridgeParameter model)
        {
            if(model == null) throw new ArgumentNullException(nameof(CreateFridgeParameter));

            var addedFridge = new Fridge
            {
                Name = model.Name,
                Description = model.Description,
                FridgeModelId = model.ModelId
            };

            Create(addedFridge);

            await RepositoryContext.SaveChangesAsync();

            if (model.Products != null && model.Products.Count() > 0)
            {
                for(int i = 0; i < model.Products.Count(); i++)
                {
                    FridgeToProduct fProduct = new FridgeToProduct()
                    {
                        FridgeId = addedFridge.Id,
                        ProductId = model.Products[i]
                    };
                    await RepositoryContext.AddAsync(fProduct);
                }
            }

            await RepositoryContext.SaveChangesAsync();

            return addedFridge.Id;
        }
    }
}
