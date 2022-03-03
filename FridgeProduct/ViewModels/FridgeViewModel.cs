using FridgeProduct.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgeProduct.ViewModels
{
    public class FridgeViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Model { get; set; }
        //[Required]
        //public string Description { get; set; }
    }
}
