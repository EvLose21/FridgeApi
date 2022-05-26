using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FridgeProduct.Contracts;
using FridgeProduct.Entities.DataTransferObjects;
using FridgeProduct.Entities.Models;
using MediatR;

namespace FridgeProduct.BusinessLayer.MediatR.Products.Commands
{
    public record CreateProductCommand(ProductForCreationDto Product) : IRequest<Guid>;

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
}
