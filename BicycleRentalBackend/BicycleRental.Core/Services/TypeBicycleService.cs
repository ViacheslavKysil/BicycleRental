using AutoMapper;
using BicycleRental.Core.Services.Interfaces;
using BicycleRental.Domain.Contracts;
using BicycleRental.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleRental.Core.Services
{
    /// <summary>
    /// Implementation of the <see cref="ITypeBicycleService"/> interface.
    /// </summary>
    public class TypeBicycleService : ITypeBicycleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeBicycleService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The instance of <see cref="IUnitOfWork"/>.</param>
        /// <param name="mapper">The instance of <see cref="IMapper"/>.</param>
        public TypeBicycleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets type of the bicycle.
        /// </summary>
        /// <param name="nameBicycle">The name of bicycle.</param>
        /// <returns> A <see cref="TypeBicycleDto"/>.</returns>
        public async Task<TypeBicycleDto> GetTypeBicycle(string nameBicycle)
        {
            var bicycleTypeModel = await _unitOfWork.TypeBicycles.SingleAsync(tb => tb.Name == nameBicycle);

            return _mapper.Map<TypeBicycleDto>(bicycleTypeModel);
        }

        /// <summary>
        /// Gets types of the bicycles.
        /// </summary>
        /// <returns> A <see cref="IEnumerable"/> of <see cref="string"/>.</returns>
        public async Task<IEnumerable<string>> GetAvailableBicycles()
        {
            var typeBicycles = await _unitOfWork.TypeBicycles.GetAllAsync();

            var listNameTypeBicycles = typeBicycles.Select(tb => tb.Name);

            return listNameTypeBicycles;
        }
    }
}
