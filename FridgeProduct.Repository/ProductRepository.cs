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

        public void CreateProdcut(Product product)
        {
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }
        public IEnumerable<ProductForFridge> GetProduct(Guid fridgeId, Guid id, bool trackChanges)
        {
            var productByFridge = RepositoryContext.FridgeToProducts
                .Where(fp => fp.FridgeId == fridgeId)
                .Select(fp => new ProductForFridge
                {
                    ProductId = id,
                    ProductName = fp.Product.Name,
                    Quantity = fp.Quantity
                })
                .OrderBy(fp => fp.Quantity);
            return productByFridge;
        }
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

            /*
            select p.ProductId, p.ProductName, fp.Quantity
	        from FridgeToProduct as fp
	        join Products as p
	        on fp.ProductId = p.ProductId
            where fp.FridgeId = '7B104622-4FEF-465A-A5D4-2015DE2C7090'
             */
        }


    }
}
