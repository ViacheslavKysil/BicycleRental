using AutoMapper;
using BicycleRental.Domain.Contracts;
using BicycleRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRental.Core.AutoMapper
{
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
