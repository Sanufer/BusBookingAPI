using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Application.DTOs.BusOperator;
using BusBooking.Application.IRepositories;
using BusBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusOperatorController : ControllerBase
    {
        private readonly IBusBookingRepository<BusOperator> _busBookingRepository;
        public BusOperatorController(IBusBookingRepository<BusOperator> busBookingRepository)
        {
            _busBookingRepository = busBookingRepository ?? throw new ArgumentNullException(nameof(busBookingRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var busOperators = await _busBookingRepository.GetAllAsync();
            return Ok(busOperators);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid guId)
        {
            var busOperator = await _busBookingRepository.GetRecordByIdAsync(guId);
            if (busOperator == null)
            {
                return NotFound();
            }
            return Ok(busOperator);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(RequestBusOperatorDto busOperatorDto)
        {
            if (busOperatorDto == null)
            {
                return BadRequest("Bus operator data cannot be null");
            }

            var busOperator = new BusOperator(busOperatorDto.Name, busOperatorDto.ContactEmail, busOperatorDto.ContactPhone);
            if (string.IsNullOrWhiteSpace(busOperator.Name) || string.IsNullOrWhiteSpace(busOperator.ContactEmail) || string.IsNullOrWhiteSpace(busOperator.ContactPhone))
            {
                return BadRequest("Bus operator name , email and contact number cannot be empty");
            }
            await _busBookingRepository.AddAsync(busOperator);
            return CreatedAtAction(nameof(GetAll), new { id = busOperator.Id }, busOperator);
        }
    }
}