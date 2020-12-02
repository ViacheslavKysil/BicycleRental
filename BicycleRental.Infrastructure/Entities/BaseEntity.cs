using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRental.Infrastructure.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
