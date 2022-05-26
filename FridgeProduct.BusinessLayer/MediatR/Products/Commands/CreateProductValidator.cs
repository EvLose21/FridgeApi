using FluentValidation;

namespace FridgeProduct.BusinessLayer.MediatR.Products.Commands
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Product.Name).NotEmpty()
                .WithMessage("Имя не может быть пустым")
                .MaximumLength(20)
                .WithMessage("Имя не может содержать более 20 символов");
        }

        /*private bool IsDuplicate(CreateProductCommand command)
        {
            var product = command.Product;

        }*/
    }
}
