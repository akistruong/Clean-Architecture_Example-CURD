using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Dtos;

namespace UseCase.MappingProfile
{
    public class AutoMapperProfile:Profile
    {
            public AutoMapperProfile() { 
            CreateMap<ProductRequest,Entities.Product>();
            CreateMap<OrderRequest, Entities.Order>();
            CreateMap<OrderItemRequest, Entities.OrderItem>();  
        }
    }
}
