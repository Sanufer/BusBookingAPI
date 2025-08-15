using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Application.DTO;
using BusBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IBusBookingRepository<City> _busBookingRepository;
        public CityController(IBusBookingRepository<City> busBookingRepository)
        {
            _busBookingRepository = busBookingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOfCities = await _busBookingRepository.GetAllAsync();
            return Ok(listOfCities);
        }
         
        [HttpPost]
        public async Task<IActionResult> AddCity(RequestCityDto requestCityDto)
        {
            if (requestCityDto == null)
            {
                return BadRequest("City data cannot be null");
            }

            var city = new City(requestCityDto.Name);
            if (string.IsNullOrWhiteSpace(city.Name))
            {
                return BadRequest("City name cannot be empty");
            }

            await _busBookingRepository.AddAsync(city);
            return CreatedAtAction(nameof(GetAll), new { id = city.Id }, city);
        }
    }
}