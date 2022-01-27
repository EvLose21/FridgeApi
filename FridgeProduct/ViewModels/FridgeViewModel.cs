using FridgeProduct.Entities.Models;
using System;
using System.Collections.Generic;

namespace FridgeProduct.ViewModels
{
    public class FridgeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
    }
}
