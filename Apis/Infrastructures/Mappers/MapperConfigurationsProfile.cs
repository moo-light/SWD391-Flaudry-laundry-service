using AutoMapper;
using Application.Commons;
using Domain.Entities;
using Application.ViewModels.UserViewModels;

namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            //CreateMap<CreateChemicalViewModel, Order>();
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            //CreateMap<Order, ChemicalViewModel>()
            //    .ForMember(dest => dest._Id, src => src.MapFrom(x => x.Id));
            //CreateMap<UserLoginDTO, UserLoginDTOResponse>()
            //    .ForMember(dest => dest.UserId, src => Guid.NewGuid())
            //    .ForMember(dest => dest.JWT, src => new BaseUser
            //    {
            //        Email = src.DestinationMember.
            //    });
        }
    }
}
