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
    public class FridgeToProductRepository : RepositoryBase<FridgeToProduct>, IFridgeModelRepository
    {
        public FridgeToProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
