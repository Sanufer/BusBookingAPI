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
        public Guid OperatorId { get; private set; }
        public BusOperator Operator { get; private set; } = default!;
        public int TotalSeats { get; private set; }
        // Seat layout is stored as JSON (rows/columns, labels, deck, etc.)
        public string SeatLayoutJson { get; private set; } = "{}";
        private readonly List<Trip> _trips = new();
        public IReadOnlyCollection<Trip> Trips => _trips;

        private Bus() { }
        public Bus(Guid operatorId, string busNumber, Enums.BusType type, int totalSeats, string layoutJson)
        {
            OperatorId = operatorId; BusNumber = busNumber; BusType = type; TotalSeats = totalSeats; SeatLayoutJson = layoutJson;
        }
    }
}