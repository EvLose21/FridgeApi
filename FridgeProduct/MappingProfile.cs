﻿using AutoMapper;
using FridgeProduct.BusinessLayer.Models;
using FridgeProduct.Entities.DataTransferObjects;
using FridgeProduct.Entities.Models;
using FridgeProduct.ViewModels;

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


            CreateMap<Product, ProductListItem>();

            CreateMap<FridgeCreateViewModel, CreateFridgeModel>();
            CreateMap<ProductCreateViewModel, CreateProductModel>();
        }
    }
}
