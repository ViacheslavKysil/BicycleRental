﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRental.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
