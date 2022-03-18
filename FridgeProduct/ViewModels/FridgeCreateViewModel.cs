using FridgeProduct.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgeProduct.ViewModels
{
    public class FridgeCreateViewModel
    {
        [Required(ErrorMessage = "Name is required field")]
        public IEnumerable<SelectListItem> ModelsList { get; set; }
        [Required(ErrorMessage = "Name is required field")]
        public IEnumerable<SelectListItem> Products { get; set; }
        [Required(ErrorMessage = "Name is required field")]
        public string Name { get; set; }
        [Required, StringLength(120, MinimumLength = 10)]
        public string Description { get; set; }
        [Required(ErrorMessage = "FridgeModel is a required field.")]
        public Guid ModelId { get; set; }
        public List<Guid> SelectedProducts { get; set;}
        
    }
}
