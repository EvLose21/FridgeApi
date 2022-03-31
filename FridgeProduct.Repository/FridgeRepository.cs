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
    }
}
