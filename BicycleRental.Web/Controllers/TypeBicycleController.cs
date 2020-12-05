using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicycleRental.Core.Services.Interfaces;
using BicycleRental.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Web.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TypeBicycleController : ControllerBase
    {
        private readonly ITypeBicycleService _typeBicycleService;

        public TypeBicycleController(ITypeBicycleService typeBicycleService)
        {
            _typeBicycleService = typeBicycleService;
        }

        [HttpGet]
        [Route("typeBicycles")]
        public async Task<IEnumerable<string>> GetAvailableBicycles()
        {
            var bicycles = await _typeBicycleService.GetAvailableBicycles();

            return bicycles;
        }
    }
}
