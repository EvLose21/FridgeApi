using System.Collections.Generic;

namespace FridgeProduct.BusinessLayer.Models
{
    public class FridgeList : BaseModel
    {
        public IEnumerable<FridgeListItem> FridgesList { get; set; }
    }
}
