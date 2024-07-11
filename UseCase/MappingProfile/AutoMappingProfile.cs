using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Order.Commands;
using UseCase.OrderItem;
using UseCase.Product.Command;

namespace UseCase.MappingProfile
{
    public sealed class AutoMappingProfile: Profile
    {
        public AutoMappingProfile()
        {
            this.CreateMap<CreateProductCommand, Entities.Product>();
            this.CreateMap<UpdateProductCommand, Entities.Product>()
                .ConvertUsing(new NullValueIgnoringConverter<UpdateProductCommand, Entities.Product>());
            this.CreateMap<PlaceOrderCommand, Entities.Order>();
            this.CreateMap<OrderItemCommand, Entities.OrderItem>();
        }
    }
}
