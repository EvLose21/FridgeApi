using FridgeProduct.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Contracts
{
    public interface IProductRepository
    {
        List<Product> GetProducts(Guid fridgeId, bool trackChanges);
        //Product GetProduct(Guid fridgeId, Guid id, bool trackChanges);
        void CreateProductsForFridge(Guid fridgeId, Product product);
    }
}
