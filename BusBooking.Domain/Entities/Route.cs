namespace BusBooking.Domain.Entities
{
    public class Route
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid SourceCityId { get; private set; }
        public City SourceCity { get; private set; } = default!;
        public Guid DestinationCityId { get; private set; }
        public City DestinationCity { get; private set; } = default!;
        public double DistanceKm { get; private set; }
        private Route() { }
        public Route(Guid source, Guid destination, double km) { SourceCityId = source; DestinationCityId = destination; DistanceKm = km; }
    }
}