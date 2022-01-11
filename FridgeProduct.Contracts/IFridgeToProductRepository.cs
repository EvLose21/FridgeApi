using FridgeProduct.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Contracts
{
    public interface IFridgeToProductRepository
    {
        IEnumerable<FridgeToProduct> GetAllFProducts(bool trackChanges);
        FridgeToProduct GetFProduct(Guid fridgeId, Guid id, bool trackChanges);
        void AddProductForFridge(FridgeToProduct fproduct);
        void DeleteProductForFridge(FridgeToProduct fproduct);
    }
}
