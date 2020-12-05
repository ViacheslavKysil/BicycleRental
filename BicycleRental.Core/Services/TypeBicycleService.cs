using AutoMapper;
using BicycleRental.Core.Services.Interfaces;
using BicycleRental.Domain.Contracts;
using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Core.Services
{
    public class TypeBicycleService : ITypeBicycleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TypeBicycleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TypeBicycleDto> GetTypeBicycle(string nameBicycle)
        {
            var bicycleTypeModel = await _unitOfWork.TypeBicycles.SingleAsync(tb => tb.Name == nameBicycle);

            return _mapper.Map<TypeBicycleDto>(bicycleTypeModel);
        }

        public async Task<IEnumerable<string>> GetAvailableBicycles()
        {
            var typeBicycles = await _unitOfWork.TypeBicycles.GetAllAsync();

            var listNameTypeBicycles = typeBicycles.Select(tb => tb.Name);

            return listNameTypeBicycles;
        }
    }
}
