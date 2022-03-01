using FridgeProduct.Entities.Models;
using System.Collections.Generic;
namespace FridgeProduct.ViewModels
{
    public class IndexFridgeViewModel
    {
        public IEnumerable<FridgeViewModel> Fridges { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
