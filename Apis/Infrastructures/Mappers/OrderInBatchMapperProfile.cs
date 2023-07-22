using Application.ViewModels.OrderInBatch;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class OrderInBatchMapperProfile : Profile
    {
        public OrderInBatchMapperProfile()
        {

            CreateMap<OrderInBatchRequestDTO, OrderInBatch>().ReverseMap();
            CreateMap<OrderInBatch, OrderInBatchResponseDTO>()
                .IncludeBase<OrderInBatch, OrderInBatchRequestDTO>()
                .ForMember(dest => dest.OrderInBatchId, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.OrderId, src => src.MapFrom(x => x.OrderId))
                .ForMember(dest => dest.BatchId, src => src.MapFrom(x => x.BatchId))
                .ReverseMap();
        }
    }
}
