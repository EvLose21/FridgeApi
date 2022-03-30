using FridgeProduct.Entities.Models;
using System.Linq;

namespace FridgeProduct.Contracts
{
    public interface IFridgeModelRepository
    {
        IQueryable<FridgeModel> GetAllFridgeModelsQuery(bool trackChanges);
    }
}
