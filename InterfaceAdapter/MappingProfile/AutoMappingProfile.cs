using AutoMapper;
using InterfaceAdapter.Order;
using InterfaceAdapter.OrderItem;
using InterfaceAdapter.Product;

namespace InterfaceAdapter.MappingProfile
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            this.CreateMap<ProductUpdateRequest, Entities.Product>()
                .ConvertUsing(new NullValueIgnoringConverter<ProductUpdateRequest, Entities.Product>());
            this.CreateMap<ProductInsertRequest, Entities.Product>();
            this.CreateMap<OrderInsertRequest, Entities.Order>();
            this.CreateMap<OrderItemRequest, Entities.OrderItem>();
        }
    }
}
