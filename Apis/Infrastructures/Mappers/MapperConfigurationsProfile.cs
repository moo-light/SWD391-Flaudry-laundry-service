using AutoMapper;
using Application.Commons;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            //CreateMap<CreateChemicalViewModel, Order>();
            //CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            //CreateMap<Order, ChemicalViewModel>()
            //    .ForMember(dest => dest._Id, src => src.MapFrom(x => x.Id));
        }
    }
}
