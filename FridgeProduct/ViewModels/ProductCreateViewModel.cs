using System.ComponentModel.DataAnnotations;

namespace FridgeProduct.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int DefaultQuantity { get; set; }
    }
}
