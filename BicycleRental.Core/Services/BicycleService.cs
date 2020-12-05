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
using System.Threading.Tasks;

namespace BicycleRental.Core.Services
{
    /// <summary>
    /// Implementation of the <see cref="IBicycleService"/> interface.
    /// </summary>
    public class BicycleService : IBicycleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITypeBicycleService _typeBicycleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BicycleService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The instance of <see cref="IUnitOfWork"/>.</param>
        /// <param name="mapper">The instance of <see cref="IMapper"/>.</param>
        /// <param name="typeBicycleService">The instance of <see cref="ITypeBicycleService"/>.</param>
        public BicycleService(IUnitOfWork unitOfWork, IMapper mapper, ITypeBicycleService typeBicycleService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _typeBicycleService = typeBicycleService;
        }

        /// <summary>
        /// Gets available bicycles.
        /// </summary>
        /// <returns> A <see cref="IEnumerable"/> of <see cref="BicycleDto"/>.</returns>
        public async Task<IEnumerable<BicycleDto>> GetAvailableBicycles()
        {
            var bicycles = await _unitOfWork.Bicycles.GetAllAsync(b => b.Include(x => x.TypeBicycle));

            var availableBicycles = bicycles.Where(b => b.RentalStatus == RentalStatus.Free);

            return _mapper.Map<IEnumerable<BicycleDto>>(availableBicycles);
        }

        /// <summary>
        /// Gets rented bicycles.
        /// </summary>
        /// <returns> A <see cref="IEnumerable"/> of <see cref="BicycleDto"/>.</returns>
        public async Task<IEnumerable<BicycleDto>> GetRentedBicycles()
        {
            var bicycles = await _unitOfWork.Bicycles.GetAllAsync(b => b.Include(x => x.TypeBicycle));

            var rentedBicycles = bicycles.Where(b => b.RentalStatus == RentalStatus.Rented);

            return _mapper.Map<IEnumerable<BicycleDto>>(rentedBicycles);
        }

        /// <summary>
        /// Creates a new bicyle.
        /// </summary>
        /// <param name="bicycleDto"></param>
        /// <returns>Task.</returns>
        public async Task CreateAsync(BicycleDto bicycleDto)
        {
            var bicycleModel = _mapper.Map<Bicycle>(bicycleDto);

            var bicycleTypeModel = await _typeBicycleService.GetTypeBicycle(bicycleDto.RentalType);

            bicycleModel.TypeBicycleId = bicycleTypeModel.Id;
            bicycleModel.RentalStatus = RentalStatus.Free;

            await _unitOfWork.Bicycles.CreateAsync(bicycleModel);

            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Deletes the bicycle.
        /// </summary>
        /// <param name="bicycleId">The identifier of bicycle.</param>
        /// <returns>Task.</returns>
        public async Task DeleteAsync(Guid bicycleId)
        {
            var bicycle = await _unitOfWork.Bicycles.SingleAsync(b => b.Id == bicycleId);

            _unitOfWork.Bicycles.Delete(bicycle);

            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Rents of the bicycle.
        /// </summary>
        /// <param name="bicycleId">The identifier of bicycle.</param>
        /// <returns>Task.</returns>
        public async Task RentBicycleAsync(Guid bicycleId)
        {
            var bicycle = await _unitOfWork.Bicycles.SingleAsync(b => b.Id == bicycleId);

            bicycle.RentalStatus = RentalStatus.Rented;

            _unitOfWork.Bicycles.Update(bicycle);

            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Cancels rent of the bicycle.
        /// </summary>
        /// <param name="bicycleId">The identifier of bicycle.</param>
        /// <returns>Task.</returns>
        public async Task CancelRentBicycleAsync(Guid bicycleId)
        {
            var bicycle = await _unitOfWork.Bicycles.SingleAsync(b => b.Id == bicycleId);

            bicycle.RentalStatus = RentalStatus.Free;

            _unitOfWork.Bicycles.Update(bicycle);

            await _unitOfWork.SaveAsync();
        }
    }
}
