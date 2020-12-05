﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRental.Domain.Entities
{
    public class Bicycle : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }

        public Guid TypeBicycleId { get; set; }
        public TypeBicycle TypeBicycle { get; set; }
    }
}