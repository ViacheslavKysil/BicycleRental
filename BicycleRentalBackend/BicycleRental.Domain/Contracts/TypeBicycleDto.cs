using System;

namespace BicycleRental.Domain.Contracts
{
    /// <summary>
    /// A data transfer object for the type of bicycle entity.
    /// </summary>
    public class TypeBicycleDto
    {
        // <summary>
        /// Gets or sets identifier of TypeBicycleDto.
        /// </summary>
        /// <value>
        /// The identifier of TypeBicycleDto.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets name of TypeBicycleDto.
        /// </summary>
        /// <value>
        /// The name of TypeBicycleDto.
        /// </value>
        public string Name { get; set; }
    }
}
