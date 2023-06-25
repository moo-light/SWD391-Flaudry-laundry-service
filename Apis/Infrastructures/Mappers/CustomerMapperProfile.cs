using Application.Utils;
using Application.ViewModels.Customer;
using Application.ViewModels.NewFolder;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class CustomerMapperProfile : Profile
    {
        public CustomerMapperProfile()
        {

            CreateMap<CustomerRegisterDTO, Customer>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password.Hash()))
                .ReverseMap();
            CreateMap<CustomerRequestDTO, Customer>().ReverseMap();
            CreateMap<CustomerRequestUpdateDTO, Customer>()
                     .ForMember(dest => dest.PasswordHash,
                                 opt =>
                                 {
                                     opt.PreCondition(x => x.NewPassword != null);//if(newpassword is null) then dont map
                                     opt.MapFrom(x => x.NewPassword.Hash());
                                 }
                                 ).ReverseMap();
            CreateMap<CustomerResponseDTO, Customer>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.CustomerId))
                .ReverseMap();
            CreateMap<LaundryOrderResponseDTO, LaundryOrder>().ReverseMap();
        }
    }
}
