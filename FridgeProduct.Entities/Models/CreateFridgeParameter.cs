using System;
using System.Collections.Generic;

namespace FridgeProduct.Entities.Models
{
    public class CreateFridgeParameter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ModelId { get; set; }
        public List<Guid> Products { get; set; }
    }
}
