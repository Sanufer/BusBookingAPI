using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Domain.Entities
{
    public class BusOperator
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = default!;
        public string ContactEmail { get; private set; } = default!;
        public string ContactPhone { get; private set; } = default!;
        private readonly List<Bus> _buses = new();
        public IReadOnlyCollection<Bus> Buses => _buses;
        private BusOperator() { }
        public BusOperator(string name, string email, string phone) { Name = name; ContactEmail = email; ContactPhone = phone; }
    }
}