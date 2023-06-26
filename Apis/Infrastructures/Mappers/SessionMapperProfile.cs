using Application.ViewModels.LaundryOrders;
using Application.ViewModels.Sessions;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class SessionMapperProfile : Profile
    {
        public SessionMapperProfile()
        {

            CreateMap<SessionRequestDTO, Session>().ReverseMap();
            CreateMap<SessionResponseDTO, Session>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.SessionId))
                .ReverseMap();
        }
    }
}
