using System;

namespace BicycleRental.Domain.Contracts
{
    /// <summary>
    /// A data transfer object for the bicycle entity.
    /// </summary>
    public class BicycleDto
    {
        /// <summary>
        /// Gets or sets identifier of BicycleDto.
        /// </summary>
        /// <value>
        /// The identifier of BicycleDto.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets name of BicycleDto.
        /// </summary>
        /// <value>
        /// The name of BicycleDto.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price of BicycleDto.
        /// </summary>
        /// <value>
        /// The price of BicycleDto.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets rental type of BicycleDto.
        /// </summary>
        /// <value>
        /// The rental type of BicycleDto.
        /// </value>
        public string RentalType { get; set; }
    }
}
