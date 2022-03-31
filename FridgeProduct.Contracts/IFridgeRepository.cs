using FridgeProduct.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Contracts
{
    public interface IFridgeRepository : IRepositoryBase<Fridge>
    {
        Task<IEnumerable<Fridge>> GetAllFridgesAsync(bool trackChanges);
        IQueryable<Fridge> GetAllFridgesQuery(bool trackChanges);
        Task<Fridge> GetFridgeAsync(Guid fridgeId, bool trackChanges);
    }
}
