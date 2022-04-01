using System;
using System.Collections.Generic;

namespace FridgeProduct.BusinessLayer.Models
{
    public class CreateFridgeModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ModelId { get; set; }
        public List<Guid> SelectedProducts { get; set; }
    }
}
