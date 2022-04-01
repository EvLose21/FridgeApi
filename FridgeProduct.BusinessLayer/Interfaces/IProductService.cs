using FridgeProduct.BusinessLayer.Models;
using System;
using System.Threading.Tasks;

namespace FridgeProduct.BusinessLayer.Interfaces
{
    public interface IProductService
    {
        Task<PaginatedList<ProductListItem>> GetProductListAsync(int? pageNumber);
        Task<Guid> CreateProductAsync(CreateProductModel model);
        Task<PaginatedList<ProductListItem>> ProductsByFridgeAsync(Guid? id, int? pageNumber);
        bool IsNameExist(string name);
    }
}
