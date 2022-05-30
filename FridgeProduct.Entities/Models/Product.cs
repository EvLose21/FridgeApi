using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeProduct.Entities.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }
        public List<Fridge> Fridges { get; set; } = new();
        public List<FridgeToProduct> FridgeToProducts { get; set; } = new();
    }
}
