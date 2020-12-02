using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRental.Infrastructure.Entities
{
    public class Bicycle : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
