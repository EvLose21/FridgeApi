using FridgeProduct.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgeProduct.ViewModels
{
    public class FridgeCreateViewModel
    {
        public IEnumerable<SelectListItem> ModelsList { get; set; }
        public IEnumerable<SelectListItem> AvailableProducts { get; set; }
        [Required(ErrorMessage = "Name is required field")]
        public string Name { get; set; }
        [Required, StringLength(120, MinimumLength = 8)]
        public string Description { get; set; }
        [Required(ErrorMessage = "FridgeModel is a required field.")]
        public Guid ModelId { get; set; }

        public List<Guid> SelectedProducts { get; set;}
    }
}
