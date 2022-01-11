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

namespace FridgeProduct.Repository
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Product> GetAllProducts(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(f => f.Name)
            .ToList();
        public void CreateProdcut(Product product)=>
            Create(product);

        public void DeleteProduct(Product product)=>
            Delete(product);
        public IEnumerable<ProductForFridge> GetProducts(Guid fridgeId, bool trackChanges)
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

        public Product GetProduct(Guid id, bool trackChanges)=>
            FindByCondition(p => p.Id.Equals(id), trackChanges)
            .SingleOrDefault();
    }
}
