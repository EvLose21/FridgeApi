using FridgeProduct.BusinessLayer.Models;
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

        public CreateFridgeModel FridgeParameters { get; set; }
    }
}
