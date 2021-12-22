using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Entities.Models
{
    public class FridgeModel
    {
        [Column("ModelId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Fridge model is a required field.")]
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
