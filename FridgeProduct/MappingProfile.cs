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
            CreateMap<FridgeForCreationDto, Fridge>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, ProductForFridge>();
        }
    }
}
