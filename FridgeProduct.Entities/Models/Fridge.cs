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
        public Guid ModelId { get; set; }
        [Required(ErrorMessage = "Fridge name is a required field.")]
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public List<Product> Products { get; set; } = new();
        public List<FridgeToProduct> FridgeToProducts { get; set; } = new();
    }
}
