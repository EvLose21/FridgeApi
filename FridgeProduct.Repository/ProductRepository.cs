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
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateProductsForFridge(Guid fridgeId, Product product)
        {
            
        }

        //public Product GetProduct(Guid fridgeId, Guid id, bool trackChanges)=>
        //  FindByCondition(p=>p.)

        /*public List<Product> GetProducts(Guid fridgeId, bool trackChanges)
        {
            var product = new Product();
            var products = product.FridgeToProducts.Where(p=>p.FridgeId == fridgeId).SingleOrDefault();

        }*/


    }
}
