using System;

namespace FridgeProduct.ViewModels
{
    public class FridgeUpdateViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
    }
}
