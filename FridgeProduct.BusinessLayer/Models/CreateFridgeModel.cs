using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgeProduct.BusinessLayer.Models
{
    public class CreateFridgeModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid ModelId { get; set; }
        [Required]
        public List<Guid> SelectedProducts { get; set; }
        public IEnumerable<SelectListItem> ModelsList { get; set; }
        public IEnumerable<SelectListItem> AvailableProducts { get; set; }
    }
}
