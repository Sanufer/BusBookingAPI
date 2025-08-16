using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Application.DTO;
using BusBooking.Application.DTO.ResponseDto;
using BusBooking.Domain.Entities;
using BusBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusController : ControllerBase
    {
        private readonly IBusBookingRepository<Bus> _busBookingRepository;
        public BusController(IBusBookingRepository<Bus> busBookingRepository)
        {
            _busBookingRepository = busBookingRepository ?? throw new ArgumentNullException(nameof(busBookingRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBuses()
        {
            var buses = await _busBookingRepository.GetAllAsync();
            if (buses == null || !buses.Any())
            {
                return NotFound("No buses found.");
            }

            var responseBusDtos = buses.Select(b => new ResponseBusDto
            {
                BusNumber = b.BusNumber,
                BusType = b.BusType,
                AcType = b.AcType,
                BusBrand = b.BusBrand,
                OperatorId = b.OperatorId,
                TotalSeats = b.TotalSeats
            }).ToList();

            return Ok(responseBusDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusById(Guid guId)
        {
            var bus = await _busBookingRepository.GetRecordByIdAsync(guId);
            if (bus == null)
            {
                return NotFound("Bus not found.");
            }

            var responseBusDto = new ResponseBusDto
            {
                BusNumber = bus.BusNumber,
                BusType = bus.BusType,
                AcType = bus.AcType,
                BusBrand = bus.BusBrand,
                OperatorId = bus.OperatorId,
                TotalSeats = bus.TotalSeats
            };

            return Ok(responseBusDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddBus([FromBody] RequestBusDto busDetailsDto)
        {
            if (busDetailsDto == null)
            {
                return BadRequest("Bus details cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(busDetailsDto.BusNumber) || busDetailsDto.TotalSeats <= 0)
            {
                return BadRequest("Bus number and total seats must be provided.");
            }

            var busDetails = new Bus(
                busDetailsDto.BusNumber,
                busDetailsDto.BusType,
                busDetailsDto.AcType,
                busDetailsDto.BusBrand,
                busDetailsDto.TotalSeats,
                busDetailsDto.OperatorId
            );

            await _busBookingRepository.AddAsync(busDetails);
            return CreatedAtAction(nameof(GetAllBuses), new { id = busDetails.Id }, busDetails);
        }
    }
}
