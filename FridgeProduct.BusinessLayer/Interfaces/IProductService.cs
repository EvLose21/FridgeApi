﻿using FridgeProduct.BusinessLayer.Models;
using System.Threading.Tasks;

namespace FridgeProduct.BusinessLayer.Interfaces
{
    public interface IProductService
    {
        Task<PaginatedList<ProductListItem>> GetProductListAsync(int? pageNumber);
    }
}
