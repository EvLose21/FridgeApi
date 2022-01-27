using FridgeProduct.Entities.Models;
using System.Collections.Generic;

namespace FridgeProduct.ViewModels
{
    public class FridgeCreateViewModel
    {
        public string Name { get; set; }
        public FridgeModel FridgeModel { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
