using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeProduct.Entities.Models
{
    public class Product
    {
        [Column("ProductId")]
        public Guid Id { get; set; }
        [Column("ProductName")]
        [Required(ErrorMessage = "Product name is a required field.")]
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }
        public List<Fridge> Fridges { get; set; } = new();
        public List<FridgeToProduct> FridgeToProducts { get; set; } = new();
    }
}
