using AutoMapper;
using Application.Commons;
using Domain.Entities;
using Application.ViewModels.UserViewModels;
using Application.Utils;
using Application.ViewModels.Customer;

namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            CreateMap(typeof(Pagination<>), typeof(List<>)).ReverseMap();
            CreateMap<DriverRegisterDTO, Driver>()
                .ForMember(dest => dest.PasswordHash, src =>src.MapFrom(x=>x.Password.Hash()))
                .ReverseMap();
            CreateMap<CustomerRegisterDTO, Customer>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password.Hash()))
                .ReverseMap();
        }
    }
}
