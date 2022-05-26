using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FridgeProduct.Contracts;
using FridgeProduct.Entities.DataTransferObjects;
using MediatR;

namespace FridgeProduct.BusinessLayer.MediatR.Fridges.Queries
{
    public record GetFridgesQuery : IRequest<IEnumerable<FridgeDto>>;

    public class GetFridgesQueryHandler : IRequestHandler<GetFridgesQuery, IEnumerable<FridgeDto>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetFridgesQueryHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FridgeDto>> Handle(GetFridgesQuery request, CancellationToken cancellationToken)
        {
            var fridges = await _repository.Fridge.GetAllFridgesAsync(trackChanges: false);
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);
            return fridgesDto;
        }
    }
}
