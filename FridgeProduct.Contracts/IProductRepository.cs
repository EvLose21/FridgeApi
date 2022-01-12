using FridgeProduct.Entities.DataTransferObjects;
using FridgeProduct.Entities.Models;
using FridgeProduct.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<ProductForFridge> GetProducts(Guid fridgeId, ProductParameters productParameters, bool trackChanges);
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
        Task<Product> GetProductAsync(Guid id, bool trackChanges);

        void CreateProdcut(Product product);
        void DeleteProduct(Product product);
    }
}
