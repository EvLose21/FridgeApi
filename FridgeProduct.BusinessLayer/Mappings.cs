using AutoMapper;
using FridgeProduct.BusinessLayer.Models;
using FridgeProduct.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.BusinessLayer
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Fridge, FridgeListItem>()
                .ForMember(f => f.Model,
                opt => opt.MapFrom(x => x.FridgeModel.Name));

            CreateMap<Fridge, CreateFridgeModel>();
        }
    }
}
