using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Application.DTO.RequestDto
{
    public class RequestRouteDto
    {
        public Guid SourceCityId { get; set; }
        public Guid DestinationCityId { get; set; }
        public double DistanceKm { get; set; }
        public TimeSpan EstimatedDuration { get; set; }
    }
}