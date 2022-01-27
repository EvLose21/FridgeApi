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
    public class FridgeToProductRepository : RepositoryBase<FridgeToProduct>, IFridgeToProductRepository
    {
        public FridgeToProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<FridgeToProduct> GetAllFProducts(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(f => f.Quantity)
            .ToList();


        public async Task<IEnumerable<FridgeToProduct>> GetMissingProductAsync(Guid fridgeId, bool trackChanges)
        {
            var missingProducts = await RepositoryContext.FridgeToProducts.FromSqlRaw($"checkprod {fridgeId}").ToListAsync();
            return missingProducts;
        }

        public void AddProductForFridge(FridgeToProduct fproduct)
        {
            var addProduct = new FridgeToProduct
            {
                ProductId = fproduct.ProductId,
                Quantity = fproduct.Quantity,
                FridgeId = fproduct.FridgeId,
            };

            Create(addProduct);
        }

        public void DeleteProductForFridge(FridgeToProduct fproduct)
        {
            Delete(fproduct);
        }

        public FridgeToProduct GetFProduct(Guid fridgeId, Guid id, bool trackChanges) =>
            FindByCondition(fp => fp.FridgeId.Equals(fridgeId) && fp.ProductId.Equals(id), trackChanges)
            .FirstOrDefault();
    }
}
