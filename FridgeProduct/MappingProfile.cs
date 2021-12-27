using AutoMapper;
using FridgeProduct.Entities.DataTransferObjects;
using FridgeProduct.Entities.Models;

namespace FridgeProduct
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fridge, FridgeDto>()
                .ForMember(f => f.Names,
                opt => opt.MapFrom(x => string.Join(' ', x.Name, x.OwnerName)));
        }
    }
}
