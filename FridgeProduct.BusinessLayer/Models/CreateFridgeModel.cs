using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgeProduct.BusinessLayer.Models
{
    public class CreateFridgeModel : BaseModel
    {
        [Display(Name = "Название холодильника")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [Required]
        public string Description { get; set; }
        [Display(Name = "Модель холодильника")]
        [Required]
        public Guid ModelId { get; set; }
        public List<Guid> SelectedProducts { get; set; }
    }
}
