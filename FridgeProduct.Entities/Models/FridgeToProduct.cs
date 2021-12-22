using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Entities.Models
{
    public class FridgeToProduct
    {
        [Required(ErrorMessage = "ProductId is a required field.")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        [Required(ErrorMessage = "FridgeId is a required field.")]
        public Guid FridgeId { get; set; }
        public Fridge Fridge { get; set; }
        [Required(ErrorMessage = "Quantity is a required field.")]
        public int Quantity { get; set; }
    }
}
