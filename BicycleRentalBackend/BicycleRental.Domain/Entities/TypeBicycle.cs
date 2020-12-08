namespace BicycleRental.Domain.Entities
{
    /// <summary>
    /// An entity representing a bicycle.
    /// </summary>
    public class TypeBicycle : BaseEntity
    {
        /// <summary>
        /// Gets or sets name of type of bicycle.
        /// </summary>
        /// <value>
        /// The name of type bicycle.
        /// </value>
        public string Name { get; set; }
    }
}
