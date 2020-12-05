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
            CreateMap<Bicycle, BicycleDto>();
            CreateMap<BicycleDto, Bicycle>();

            CreateMap<RentalStatus, RentalStatusDto>();
            CreateMap<RentalStatusDto, RentalStatus>();

            CreateMap<TypeBicycle, TypeBicycleDto>();
            CreateMap<TypeBicycleDto, TypeBicycle>();
        }
    }
}
