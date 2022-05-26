using System;

namespace FridgeProduct.BusinessLayer.Models
{
    public class ReturnProduct
    {
        public Guid Id { get; set; }
        public EnumProductValidation Status { get; set; }
    }
}
