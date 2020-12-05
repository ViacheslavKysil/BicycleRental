using BicycleRental.Domain.Enums;
using System;

namespace BicycleRental.Domain.Entities
{
    /// <summary>
    /// An entity representing a bicycle.
    /// </summary>
    public class Bicycle : BaseEntity
    {
        /// <summary>
        /// Gets or sets name of bicycle.
        /// </summary>
        /// <value>
        /// The name of bicycle.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price of bicycle.
        /// </summary>
        /// <value>
        /// The price of bicycle.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets rental type of bicycle.
        /// </summary>
        /// <value>
        /// The rental type of bicycle.
        /// </value>
        public RentalStatus RentalStatus { get; set; }

        /// <summary>
        /// Gets or sets foregin key.
        /// </summary>
        /// <value>
        /// The identifier type of bicycle.
        /// </value>
        public Guid TypeBicycleId { get; set; }

        /// <summary>
        /// Gets or sets navigation property.
        /// </summary>
        /// <value>
        /// The navigation property to type of bicyle.
        /// </value>
        public TypeBicycle TypeBicycle { get; set; }
    }
}
