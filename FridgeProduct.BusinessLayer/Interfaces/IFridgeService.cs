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
        Task<List<SelectListItem>> InitModelsList();
        Task<List<SelectListItem>> InitProductsList();
        Task<Guid> CreateFridgeAsync(CreateFridgeModel model);

    }
}
