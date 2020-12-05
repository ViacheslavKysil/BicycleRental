using AutoMapper;
using BicycleRental.Core.Services.Interfaces;
using BicycleRental.Domain.Contracts;
using BicycleRental.Domain.Entities;
using BicycleRental.Domain.Enums;
using BicycleRental.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Core.Services
{
    public class BicycleService : IBicycleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITypeBicycleService _typeBicycleService;

        public BicycleService(IUnitOfWork unitOfWork, IMapper mapper, ITypeBicycleService typeBicycleService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _typeBicycleService = typeBicycleService;
        }

        public async Task<IEnumerable<BicycleDto>> GetAvailableBicycles()
        {
            var bicycles = await _unitOfWork.Bicycles.GetAllAsync(b => b.Include(x => x.TypeBicycle));

            var availableBicycles = bicycles.Where(b => b.RentalStatus == RentalStatus.Free);

            return _mapper.Map<IEnumerable<BicycleDto>>(availableBicycles);
        }

        public async Task<IEnumerable<BicycleDto>> GetRentedBicycles()
        {
            var bicycles = await _unitOfWork.Bicycles.GetAllAsync(b => b.Include(x => x.TypeBicycle));

            var rentedBicycles = bicycles.Where(b => b.RentalStatus == RentalStatus.Rented);

            return _mapper.Map<IEnumerable<BicycleDto>>(rentedBicycles);
        }

        public async Task CreateAsync(BicycleDto bicycleDto)
        {
            var bicycleModel = _mapper.Map<Bicycle>(bicycleDto);

            var bicycleTypeModel = await _typeBicycleService.GetTypeBicycle(bicycleDto.RentalType);

            bicycleModel.TypeBicycleId = bicycleTypeModel.Id;
            bicycleModel.RentalStatus = RentalStatus.Free;

            await _unitOfWork.Bicycles.CreateAsync(bicycleModel);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid bicycleId)
        {
            var bicycle = await _unitOfWork.Bicycles.SingleAsync(b => b.Id == bicycleId);

            _unitOfWork.Bicycles.Delete(bicycle);

            await _unitOfWork.SaveAsync();
        }

        public async Task RentBicycleAsync(Guid bicycleId)
        {
            var bicycle = await _unitOfWork.Bicycles.SingleAsync(b => b.Id == bicycleId);

            bicycle.RentalStatus = RentalStatus.Rented;

            _unitOfWork.Bicycles.Update(bicycle);

            await _unitOfWork.SaveAsync();
        }

        public async Task CancelRentBicycleAsync(Guid bicycleId)
        {
            var bicycle = await _unitOfWork.Bicycles.SingleAsync(b => b.Id == bicycleId);

            bicycle.RentalStatus = RentalStatus.Free;

            _unitOfWork.Bicycles.Update(bicycle);

            await _unitOfWork.SaveAsync();
        }
    }
}
