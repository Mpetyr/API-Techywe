using API_Tecnywe.Entities;
using AutoMapper;
using static API_Tecnywe.DTO.Customer;
using static API_Tecnywe.DTO.Order;
using static API_Tecnywe.DTO.Product;

namespace API_Tecnywe.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();

            CreateMap<Order, OrderDto>();

            CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<Order, OrderResponseDto>()
                .ForMember(dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.OrderDetails,
                    opt => opt.MapFrom(src => src.OrderDetails));
        }
    }
}
