using Application.ViewModels.Batchs;
using Application.ViewModels.Feedbacks;
using Application.ViewModels.FilterModels;
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
            CreateMap<BatchResponseDTO, Batch>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.BatchId))
                .ReverseMap();
        }
    }
}
