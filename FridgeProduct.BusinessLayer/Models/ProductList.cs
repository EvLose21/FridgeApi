using System.Collections.Generic;

namespace FridgeProduct.BusinessLayer.Models
{
    public class ProductList : BaseModel
    {
        public IEnumerable<ProductListItem> ProductsList { get; set; }
    }
}
