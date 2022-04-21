using FluentValidation;
using FridgeProduct.Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Entities.Models
{
    public class ProductValidate : AbstractValidator<Product>
    {
        public ProductValidate()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}
