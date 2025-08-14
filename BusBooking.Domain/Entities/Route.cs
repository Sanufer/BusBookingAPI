namespace BusBooking.Domain.Entities
{
    public class Route
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid SourceCityId { get; private set; }
        public Guid DestinationCityId { get; private set; }
        public double DistanceKm { get; private set; }
        private Route() { }
        public Route(Guid source, Guid destination, double km) { SourceCityId = source; DestinationCityId = destination; DistanceKm = km; }
    }
}