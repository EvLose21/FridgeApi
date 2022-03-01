using FridgeProduct.Contracts;
using FridgeProduct.Entities;
using FridgeProduct.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FridgeProduct.Entities.DataTransferObjects;
using FridgeProduct.Entities.RequestFeatures;

namespace FridgeProduct.Repository
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(f => f.Name)
            .ToListAsync();
        public void CreateProdcut(Product product)=>
            Create(product);

        public void DeleteProduct(Product product)=>
            Delete(product);
        public IEnumerable<ProductForFridge> GetProducts(Guid fridgeId, ProductParameters productParameters, bool trackChanges)
        {
            var productsByFridge = RepositoryContext.FridgeToProducts
                .Where(fp => fp.FridgeId == fridgeId)
                .Select(fp => new ProductForFridge
                {
                    ProductId = fp.ProductId,
                    ProductName = fp.Product.Name,
                    Quantity = fp.Quantity
                })
                .OrderBy(fp => fp.Quantity);
            return productsByFridge;
        }

        public async Task<Product> GetProductAsync(Guid id, bool trackChanges)=>
            await FindByCondition(p => p.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }
}
