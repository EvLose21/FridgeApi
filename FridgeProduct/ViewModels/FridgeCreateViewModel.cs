using FridgeProduct.BusinessLayer.Models;
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

        [Display(Name = "Название холодильника")]
        [StringLength(20, MinimumLength = 3)]
        [Required(ErrorMessage = "Введите название холодильника")]
        //[Required]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Модель холодильника")]
        [Required(ErrorMessage = "Выберите модель холодильника")]
        public Guid ModelId { get; set; }
        public List<Guid> SelectedProducts { get; set; }
    }
}
