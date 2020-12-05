using AutoMapper;
using BicycleRental.Domain.Contracts;
using BicycleRental.Domain.Entities;

namespace BicycleRental.Core.AutoMapper
{
    /// <summary>
    /// Class containing the mapping settings for core layer using AutoMapper.
    /// </summary>
    public class CoreMapperProfile : Profile
    {
        public CoreMapperProfile()
        {
            CreateMap<Bicycle, BicycleDto>()
                .ForMember(dest => dest.RentalType,
                    opt => opt.MapFrom(x => x.TypeBicycle.Name));
            CreateMap<BicycleDto, Bicycle>();

            CreateMap<TypeBicycle, TypeBicycleDto>();
        }
    }
}
