using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        [Column("ProductId")]
        public Guid Id { get; set; }
        [Column("ProductName")]
        [Required(ErrorMessage = "Product name is a required field.")]
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }
        public int FridgeId { get; set; }
        public List<Fridge> Fridges { get; set; } = new();
    }
}
