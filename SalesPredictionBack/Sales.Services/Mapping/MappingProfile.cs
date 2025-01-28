using AutoMapper;
using Sales.Data.Entities;
using Sales.DataAccess.Data;
using Sales.Services.DTOs;

namespace Sales.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeesEntity, EmployeesDTO>()
                .ForMember(dest => dest.EmpId, opt => opt.MapFrom(src => src.EmpId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Firstname + " " + src.Lastname));

            CreateMap<ShippersEntity, ShippersDTO>()
                .ForMember(dest => dest.ShipperId, opt => opt.MapFrom(src => src.ShipperId))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName));

            CreateMap<ProductsEntity, ProductsDTO>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName));

            CreateMap<OrdersEntity, OrdersDTO>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.RequiredDate, opt => opt.MapFrom(src => src.RequiredDate))
                .ForMember(dest => dest.ShippedDate, opt => opt.MapFrom(src => src.ShippedDate))
                .ForMember(dest => dest.ShipName, opt => opt.MapFrom(src => src.ShipName))
                .ForMember(dest => dest.ShipAddress, opt => opt.MapFrom(src => src.ShipAddress))
                .ForMember(dest => dest.ShipCity, opt => opt.MapFrom(src => src.ShipCity));
        }
    }
}
