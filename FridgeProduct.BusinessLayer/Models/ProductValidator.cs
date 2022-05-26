using FluentValidation;

namespace FridgeProduct.BusinessLayer.Models
{
    public class ProductValidator : AbstractValidator<CreateProductModel>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
