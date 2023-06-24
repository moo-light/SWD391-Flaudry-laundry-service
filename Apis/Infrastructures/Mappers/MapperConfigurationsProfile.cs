using AutoMapper;
using Application.Commons;
using Domain.Entities;
using Application.ViewModels.UserViewModels;
using Application.Utils;
using Application.ViewModels.FilterModels;

namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            //CreateMap<CreateChemicalViewModel, Order>();
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            CreateMap(typeof(Pagination<>), typeof(List<>)).ReverseMap();
            //CreateMap<Order, ChemicalViewModel>()
            //    .ForMember(dest => dest._Id, src => src.MapFrom(x => x.Id));
            //CreateMap<UserLoginDTO, UserLoginDTOResponse>()
            //    .ForMember(dest => dest.UserId, src => Guid.NewGuid())
            //    .ForMember(dest => dest.JWT, src => new BaseUser
            //    {
            //        Email = src.DestinationMember.
            //    });

            CreateMap<DriverRegisterDTO, Driver>()
                .ForMember(dest => dest.PasswordHash, src =>src.MapFrom(x=>x.Password.Hash()))
                .ReverseMap();
            CreateMap<CustomerRegisterDTO, Customer>()
                .ForMember(dest => dest.FullName, src => src.MapFrom(x =>  x.FullName))
                .ForMember(dest => dest.Email, src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.PhoneNumber, src => src.MapFrom(x => x.PhoneNumber))
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password.Hash()))
                .ForMember(dest => dest.Address, src => src.MapFrom(x => x.Address))
                .ReverseMap();
            CreateMap<CustomerFilteringModel, Customer>()
                .ForMember(dest => dest.FullName, src => src.MapFrom(x => x.FullName))
                .ForMember(dest => dest.Email, src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.PhoneNumber, src => src.MapFrom(x => x.PhoneNumber))
                .ForMember(dest => dest.Address, src => src.MapFrom(x => x.Address))
                .ReverseMap();
        }
    }
}
