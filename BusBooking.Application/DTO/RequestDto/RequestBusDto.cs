using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Domain.Entities;

namespace BusBooking.Application.DTO
{
    public class RequestBusDto
    {
        public string BusNumber { get; set; } = default!;
        public Domain.Enums.BusType BusType { get; set; }
        public Domain.Enums.AcType AcType { get; set; }
        public Domain.Enums.BusBrand BusBrand { get; set; }
        public int TotalSeats { get; set; }
        public Guid OperatorId { get; set; }
    }
}