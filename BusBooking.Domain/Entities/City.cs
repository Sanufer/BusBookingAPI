namespace BusBooking.Domain.Entities
{
    public class City
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = default!;
        private City() { }
        public City(string name) => Name = name;
    }
}