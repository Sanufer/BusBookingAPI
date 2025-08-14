namespace BusBooking.Domain.Entities
{
    public class Trip
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid BusId { get; private set; }
        public Guid RouteId { get; private set; }
        public DateTimeOffset DepartureTime { get; private set; }
        public DateTimeOffset ArrivalTime { get; private set; }
        public decimal PricePerSeat { get; private set; }
        // Snapshot of available seats for quick lookups
        private readonly HashSet<string> _availableSeats = new();
        public IReadOnlyCollection<string> AvailableSeats => _availableSeats;

        private Trip() { }
        public Trip(Guid busId, Guid routeId, DateTimeOffset dep, DateTimeOffset arr, decimal price, IEnumerable<string> seats)
        {
            BusId = busId; RouteId = routeId; DepartureTime = dep; ArrivalTime = arr; PricePerSeat = price;
            _availableSeats = seats is null ? new() : new(seats);
        }

        public bool TryHoldSeats(IEnumerable<string> seats)
        {
            if (!seats.All(s => _availableSeats.Contains(s))) return false;
            foreach (var s in seats) _availableSeats.Remove(s);
            return true;
        }
        public void ReleaseSeats(IEnumerable<string> seats)
        {
            foreach (var s in seats) _availableSeats.Add(s);
        }
    }
}