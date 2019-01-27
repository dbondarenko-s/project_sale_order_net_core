using AutoMapper;
using Ciam.DAL.Entities;
using Ciam.Models;

namespace Ciam.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SalesStatus, SalesStatusViewModel>();
            CreateMap<SalesStatusViewModel, SalesStatus>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
