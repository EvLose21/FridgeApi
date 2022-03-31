using System;

namespace FridgeProduct.BusinessLayer.Models
{
    public class FridgeListItem : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
    }
}
