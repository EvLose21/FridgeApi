using AutoMapper;
using FridgeProduct.Entities.DataTransferObjects;
using FridgeProduct.Entities.Models;

namespace FridgeProduct
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fridge, FridgeDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<FridgeToProduct, FridgeToProductDto>();

            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>();
            CreateMap<FridgeToProductForCreationDto, FridgeToProduct>();
            CreateMap<FridgeForUpdateDto, Fridge>();

            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
