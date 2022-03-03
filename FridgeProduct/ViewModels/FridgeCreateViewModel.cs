using FridgeProduct.Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgeProduct.ViewModels
{
    public class FridgeCreateViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Name { get; set; }
        public List<string> FridgeModel { get; set; }
        public string Description { get; set; }
        public List<string> Products { get; set; }
    }
}
