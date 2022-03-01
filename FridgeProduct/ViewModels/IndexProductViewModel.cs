using System.Collections.Generic;

namespace FridgeProduct.ViewModels
{
    public class IndexProductViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
