using Application.ViewModels.Batchs;
using Application.ViewModels.Feedbacks;
using Application.ViewModels.FilterModels;
using Application.ViewModels.OrderInBatch;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Mappers
{
    public class BatchMapperProfile : Profile
    {
        public BatchMapperProfile() 
        {
            CreateMap<BatchRequestDTO, Batch>().ReverseMap();
            CreateMap<BatchRequestDTO_V2, Batch>().ReverseMap();
            CreateMap<Batch, BatchResponseDTO>()
                .ForMember(dest => dest.BatchId, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.OrderInBatch, src => src.MapFrom(x => x.OrderInBatches))
                .ForMember(dest => dest.Driver, src => src.MapFrom(x => x.Driver))
                //.AfterMap((src, dest, context) =>
                //{
                //    if (dest.Driver != null)
                //    {
                //        dest.Driver.BatchResponses = null;
                //    }
                //})
                .ReverseMap();
        }
    }
}
