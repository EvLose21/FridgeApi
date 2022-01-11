﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Entities.DataTransferObjects
{
    public class FridgeForUpdateDto
    {
        [Required(ErrorMessage = "Fridge model id is a required field.")]
        public Guid ModelId { get; set; }
        [Required(ErrorMessage = "Fridge name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }
        public string OwnerName { get; set; }
        //public IEnumerable<Product> Products { get; set; }
    }
}
