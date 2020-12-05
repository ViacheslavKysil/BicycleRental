using AutoMapper;
using BicycleRental.Core.Services.Interfaces;
using BicycleRental.Domain.Contracts;
using BicycleRental.Domain.Entities;
using BicycleRental.Domain.Enums;
using BicycleRental.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            //var bicycles = await _unitOfWork.Bicycles.GetAllAsync(g => g
            //    .Include(igg => igg.TypeBicycle).ThenInclude(ig => ig.Name));
            var bicycles = await _unitOfWork.Bicycles.GetAllAsync();

            var availableBicycles = bicycles.Where(b => b.RentalStatus == RentalStatus.Free);

            var bicycleDtos = new List<BicycleDto>();

            foreach (var item in availableBicycles)
            {
                bicycleDtos.Add(new BicycleDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    RentalType = await _typeBicycleService.GetTypeBicycle2(item.TypeBicycleId)
                });
            }

            return bicycleDtos;
        }

        public async Task<IEnumerable<BicycleDto>> GetRentedBicycles()
        {
            var bicycles = await _unitOfWork.Bicycles.GetAllAsync();

            var availableBicycles = bicycles.Where(b => b.RentalStatus == RentalStatus.Rented);

            var bicycleDtos = new List<BicycleDto>();

            foreach (var item in availableBicycles)
            {
                bicycleDtos.Add(new BicycleDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    RentalType = await _typeBicycleService.GetTypeBicycle2(item.TypeBicycleId)
                });
            }

            return bicycleDtos;
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

        public async Task DeleteAsync(Guid id)
        {
            var bicycle = await _unitOfWork.Bicycles.SingleAsync(b => b.Id == id);

            _unitOfWork.Bicycles.Delete(bicycle);

            await _unitOfWork.SaveAsync();
        }

        public Task UpdateAsync(BicycleDto bicycleDto)
        {
            throw new NotImplementedException();
        }

        public async Task RentBicycleAsync(Guid id)
        {
            var bicycle = await _unitOfWork.Bicycles.SingleAsync(b => b.Id == id);

            bicycle.RentalStatus = RentalStatus.Rented;

            _unitOfWork.Bicycles.Update(bicycle);

            await _unitOfWork.SaveAsync();
        }

        public async Task CancelRentBicycleAsync(Guid id)
        {
            var bicycle = await _unitOfWork.Bicycles.SingleAsync(b => b.Id == id);

            bicycle.RentalStatus = RentalStatus.Free;

            _unitOfWork.Bicycles.Update(bicycle);

            await _unitOfWork.SaveAsync();
        }
    }
}
