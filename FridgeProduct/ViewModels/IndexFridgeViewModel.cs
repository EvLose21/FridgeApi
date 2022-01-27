using FridgeProduct.Entities.Models;
using System.Collections.Generic;
namespace FridgeProduct.ViewModels
{
    public class IndexFridgeViewModel
    {
        public IEnumerable<Fridge> Fridges { get; set; }
        public IEnumerable<FridgeModel> FridgeModels { get; set; }
    }
}
