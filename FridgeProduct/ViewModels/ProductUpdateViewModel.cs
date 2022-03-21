using System;

namespace FridgeProduct.ViewModels
{
    public class ProductUpdateViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }
    }
}
