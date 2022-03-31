using FridgeProduct.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace FridgeProduct.BusinessLayer.Interfaces
{
    public interface IFridgeService
    {
        Task<PaginatedList<FridgeListItem>> GetFridgeListAsync(int? pageNumber);
        Task<List<SelectListItem>> GetFridgeModels();
        Task<List<SelectListItem>> GetProductNames();
        Task<Guid> CreateFridgeAsync(CreateFridgeModel model);
        void DeleteFridge(Guid id);

    }
}
