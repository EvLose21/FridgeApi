using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Fridge
    {
        [Column("FridgeId")]
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        [Required(ErrorMessage = "Fridge name is a required field.")]
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public List<Product> Products { get; set; } = new();
        public int ProductId { get; set; }
    }
}
