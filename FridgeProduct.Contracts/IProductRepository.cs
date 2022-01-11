using FridgeProduct.Entities.DataTransferObjects;
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
        IEnumerable<ProductForFridge> GetProducts(Guid fridgeId, bool trackChanges);
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product GetProduct(Guid id, bool trackChanges);

        void CreateProdcut(Product product);
        void DeleteProduct(Product product);
    }
}
