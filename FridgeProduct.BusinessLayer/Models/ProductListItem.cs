using System;

namespace FridgeProduct.BusinessLayer.Models
{
    public class ProductListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }
    }
}
