using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FridgeProduct.BusinessLayer.MediatR.Abstractions;
using FridgeProduct.Contracts;
using FridgeProduct.Entities.DataTransferObjects;
using FridgeProduct.Entities.Models;
using MediatR;

namespace FridgeProduct.BusinessLayer.MediatR.Products.Commands
{
    public record CreateProductCommand(ProductForCreationDto Product) : ICommand<Guid>;

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request.Product);
            _repository.Product.CreateProdcut(productEntity);
            await _repository.SaveAsync();

            var productToReturn = _mapper.Map<ProductDto>(productEntity);

            return productToReturn.Id;
        }
    }

    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IRepositoryManager _repositoryManager;
        public CreateProductValidator(IRepositoryManager repositoryManager)
        {
            RuleFor(x => x.Product.Name)
                .NotEmpty();

            //RuleFor(x => x.Product.Name).Must(x => !IsDuplicate(x));

            RuleFor(x => x.Product.DefaultQuantity)
                .NotEmpty()
                .InclusiveBetween(1,100);

            _repositoryManager = repositoryManager;
        }

        /*private bool IsDuplicate(CreateProductCommand createProductCommand)
        {
            var product = createProductCommand.Product;

            return _repositoryManager.Product.GetAllProductsQuery(trackChanges: false).Any(p => p.Name == product.Name);
        }*/
    }
}
