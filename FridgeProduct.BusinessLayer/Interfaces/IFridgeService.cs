using FridgeProduct.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.BusinessLayer.Interfaces
{
    public interface IFridgeService
    {
        Task<FridgeList> GetFridgeListAsync();
        Task<PaginatedList<FridgeListitem>> GetFridgeListAsync1(int? pageNumber);

    }
}
