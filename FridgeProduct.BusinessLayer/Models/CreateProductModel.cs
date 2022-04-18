using System.ComponentModel.DataAnnotations;

namespace FridgeProduct.BusinessLayer.Models
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }

        public EnumProductValidation ProductType { get; set; }
        
    }
}
