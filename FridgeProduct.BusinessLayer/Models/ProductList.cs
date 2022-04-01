using System.Collections.Generic;

namespace FridgeProduct.BusinessLayer.Models
{
    public class ProductList
    {
        public IEnumerable<ProductListItem> ProductsList { get; set; }
    }
}
