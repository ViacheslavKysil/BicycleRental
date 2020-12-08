using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BicycleRental.Core.Services.Interfaces;
using BicycleRental.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Web.Controllers
{
    [ApiController]
    public class BicycleController : ControllerBase
    {
        private readonly IBicycleService _bicycleService;

        public BicycleController(IBicycleService bicycleService)
        {
            _bicycleService = bicycleService;
        }

        [HttpGet]
        [Route("bicycles/available")]
        public async Task<IEnumerable<BicycleDto>> GetAvailableBicycles()
        {
            var bicycles = await _bicycleService.GetAvailableBicycles();

            return bicycles;
        }

        [HttpGet]
        [Route("bicycles/rented")]
        public async Task<IEnumerable<BicycleDto>> GetRentedBicycles()
        {
            var bicycles = await _bicycleService.GetRentedBicycles();

            return bicycles;
        }

        [HttpPost]
        [Route("bicycle/new")]
        public async Task<IActionResult> CreateAsync([FromBody] BicycleDto bicycleDto)
        {
            await _bicycleService.CreateAsync(bicycleDto);

            return Ok();
        }

        [HttpDelete]
        [Route("bicycle/remove/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _bicycleService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        [Route("bicycle/rent/{id}")]
        public async Task<IActionResult> RentAsync(Guid id)
        {
            await _bicycleService.RentBicycleAsync(id);

            return Ok();
        }

        [HttpPut]
        [Route("bicycle/cancelRent/{id}")]
        public async Task<IActionResult> CancelRentAsync(Guid id)
        {
            await _bicycleService.CancelRentBicycleAsync(id);

            return Ok();
        }
    }
}
