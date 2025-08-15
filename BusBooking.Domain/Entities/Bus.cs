using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Domain.Entities
{
    public class Bus
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string BusNumber { get; private set; } = default!;
        public Enums.BusType BusType { get; private set; }
        public Enums.AcType AcType { get; private set; }
        public Enums.BusBrand BusBrand { get; private set; }

        public int TotalSeats { get; private set; }

        public Guid OperatorId { get; private set; }
        public BusOperator Operator { get; private set; } = default!;

        // Seat layout is stored as JSON (rows/columns, labels, deck, etc.)
        //public string SeatLayoutJson { get; private set; } = "{}";

        private readonly List<Trip> _trips = new();
        public IReadOnlyCollection<Trip> Trips => _trips;

        private Bus() { }
        public Bus(string busNumber, Enums.BusType busType, Enums.AcType acType, Enums.BusBrand busBrand, int totalSeats, Guid operatorId)
        {
            BusNumber = busNumber; BusType = busType; AcType = acType; BusBrand = busBrand; TotalSeats = totalSeats; OperatorId = operatorId; 
        }
    }
}