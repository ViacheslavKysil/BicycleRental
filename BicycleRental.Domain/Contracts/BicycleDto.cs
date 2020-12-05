using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRental.Domain.Contracts
{
    public class BicycleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string RentalType { get; set; }
    }
}
