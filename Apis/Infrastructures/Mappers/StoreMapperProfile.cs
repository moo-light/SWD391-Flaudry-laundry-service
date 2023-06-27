using Application.Utils;
using Application.ViewModels.LaundryOrders;
using AutoMapper;
using Domain.Entities;
using Application.ViewModels.Stores;

namespace Infrastructures.Mappers
{
    public class StoreMapperProfile : Profile
    {
        public StoreMapperProfile()
        {

            CreateMap<StoreRequestDTO, Store>().ReverseMap();
            CreateMap<StoreResponseDTO, Store>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.StoreId))
                .ReverseMap();
        }
    }
}
