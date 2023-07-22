using Application.Utils;
using Application.ViewModels.StoreManagers;
using Application.ViewModels.LaundryOrders;
using Application.ViewModels.Stores;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class StoreManagerMapperProfile : Profile
    {
        public StoreManagerMapperProfile()
        {
            CreateMap<StoreManagerRegisterDTO, StoreManager>()
               .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password.Hash()))
               .ReverseMap();
            CreateMap<StoreManagerRequestDTO, StoreManager>()
               .ReverseMap();
            CreateMap<StoreManagerResponseDTO, StoreManager>()
                //.ForMember(dest => dest.Batches, src => src.MapFrom(x => x.BatchResponses))
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.StoreManagerId))
                .ReverseMap();

        }
    }
}
