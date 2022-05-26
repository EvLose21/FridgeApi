using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FridgeProduct.Contracts;
using FridgeProduct.Entities.DataTransferObjects;
using MediatR;

namespace FridgeProduct.BusinessLayer.MediatR.Products.Queries
{
    public record GetProductByIdQuery(Guid id) : IRequest<ProductDto>;

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.Product.GetProductAsync(request.id, trackChanges: false);

            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;

        }
    }

}
