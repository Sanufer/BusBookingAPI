using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Application.DTO.ResponseDto;
using BusBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using BusBooking.Domain.Entities;
using BusBooking.Application.DTO.RequestDto;

namespace BusBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IBusBookingRepository<Domain.Entities.Route> _busBookingRepository;
        public RouteController(IBusBookingRepository<Domain.Entities.Route> busBookingRepository)
        {
            _busBookingRepository = busBookingRepository ?? throw new ArgumentNullException(nameof(busBookingRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoutes()
        {
            var routes = await _busBookingRepository.GetAllAsync();
            if (routes == null || !routes.Any())
            {
                return NotFound("No routes found.");
            }

            var dtoList = routes.Select(route => new ResponseRouteDto
            {
                SourceCityId = route.SourceCityId,
                DestinationCityId = route.DestinationCityId,
                DistanceKm = route.DistanceKm,
                EstimatedDuration = route.EstimatedDuration
            }).ToList();

            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRouteById(Guid guId)
        {
            var route = await _busBookingRepository.GetRecordByIdAsync(guId);
            if (route == null)
            {
                return NotFound("Route not found.");
            }

            var responseRouteDto = new ResponseRouteDto
            {
                SourceCityId = route.SourceCityId,
                DestinationCityId = route.DestinationCityId,
                DistanceKm = route.DistanceKm,
                EstimatedDuration = route.EstimatedDuration
            };

            return Ok(responseRouteDto);
        }


        [HttpPost]
        public async Task<IActionResult> AddRoute([FromBody] RequestRouteDto requestRouteDto)
        {
            if (requestRouteDto == null)
            {
                return BadRequest("Route data cannot be null.");
            }

            if (requestRouteDto.SourceCityId == Guid.Empty || requestRouteDto.DestinationCityId == Guid.Empty ||
                requestRouteDto.DistanceKm <= 0 || requestRouteDto.EstimatedDuration <= TimeSpan.Zero)
            {
                return BadRequest("Invalid route data provided.");
            }

            var route = new Domain.Entities.Route(
                requestRouteDto.SourceCityId,
                requestRouteDto.DestinationCityId,
                requestRouteDto.DistanceKm,
                requestRouteDto.EstimatedDuration);

            await _busBookingRepository.AddAsync(route);
            return CreatedAtAction(nameof(GetAllRoutes), new { id = route.Id }, route);
        }
    }
}