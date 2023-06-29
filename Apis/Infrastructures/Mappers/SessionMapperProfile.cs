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

            CreateMap<SessionRequestDTO, BatchOfBuilding>().ReverseMap();
            CreateMap<SessionResponseDTO, BatchOfBuilding>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.BatchOfBuildingId))
                .ReverseMap();
        }
    }
}
