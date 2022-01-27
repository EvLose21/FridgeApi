using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Entities.Models
{
    public class Fridge
    {
        [Column("FridgeId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "ModelId is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the model is 60 characters.")]
        public Guid FridgeModelId { get; set; }
        [Required(ErrorMessage = "Fridge name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public FridgeModel FridgeModel { get; set; }
        public List<Product> Products { get; set; } = new();
        public List<FridgeToProduct> FridgeToProducts { get; set; } = new();
    }
}
