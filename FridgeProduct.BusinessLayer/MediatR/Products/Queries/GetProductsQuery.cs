using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FridgeProduct.Contracts;
using FridgeProduct.Entities;
using FridgeProduct.Entities.DataTransferObjects;
using MediatR;

namespace FridgeProduct.BusinessLayer.MediatR.Products.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<ProductDto>>;

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.Product.GetAllProductsAsync(trackChanges: false);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productsDto;
        }
    }
}
