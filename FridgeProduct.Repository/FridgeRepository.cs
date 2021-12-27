using FridgeProduct.Contracts;
using FridgeProduct.Entities;
using FridgeProduct.Entities.Models;
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

        public IEnumerable<Fridge> GetAllFridges(bool trackChanges)=>
            FindAll(trackChanges)
            .OrderBy(f=>f.Name)
            .ToList();

        public Fridge GetFridge(Guid fridgeId, bool trackChanges)=>
            FindByCondition(f => f.Id.Equals(fridgeId), trackChanges)
            .SingleOrDefault();
    }
}
