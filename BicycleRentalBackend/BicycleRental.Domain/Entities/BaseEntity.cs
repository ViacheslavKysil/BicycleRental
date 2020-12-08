using System;

namespace BicycleRental.Domain.Entities
{
    /// <summary>
    /// The entity from which all entities inherit.
    /// Contains a unique identifier for the entity, and a soft delete field.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets IsDeleted in true or false state.
        /// </summary>
        /// <value>
        /// The IsDeleted.
        /// </value>
        public bool IsDeleted { get; set; }
    }
}
