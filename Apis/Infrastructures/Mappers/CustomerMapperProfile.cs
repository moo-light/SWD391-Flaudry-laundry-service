using Application.Utils;
using Application.ViewModels.Customer;
using Application.ViewModels.NewFolder;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class CustomerMapperProfile :Profile
    {
        public CustomerMapperProfile()
        {

            CreateMap<CustomerRegisterDTO, Customer>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password.Hash()))
                .ReverseMap();
            CreateMap<CustomerRequestDTO, Customer>().ReverseMap();
            CreateMap<CustomerResponseDTO, Customer>().ReverseMap();
            CreateMap<LaundryOrderResponseDTO, LaundryOrder>().ReverseMap();
        }
    }
}
