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
                .ForMember(dest => dest.DriverId, src => src.MapFrom(x => x.DriverId))
                .ForMember(dest => dest.FromTime, src => src.MapFrom(x => x.FromTime))
                .ForMember(dest => dest.ToTime, src => src.MapFrom(x => x.ToTime))
                .ForMember(dest => dest.CreationDate, src => src.MapFrom(x => x.CreationDate))
                .ForMember(dest => dest.ModificationDate, src => src.MapFrom(x => x.ModificationDate))
                .ForMember(dest => dest.Type, src => src.MapFrom(x => x.Type))
                .ForMember(dest => dest.Status, src => src.MapFrom(x => x.Status))
                .ReverseMap();
        }
    }
}
