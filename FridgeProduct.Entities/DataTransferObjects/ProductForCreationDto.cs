using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Entities.DataTransferObjects
{
    public class ProductForCreationDto
    {
        [Required(ErrorMessage = "Proudct name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Default Quantity is required and can't be lower than 0")]
        public int DefaultQuantity { get; set; }
    }
}
