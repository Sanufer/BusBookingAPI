using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FullName { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string Phone { get; private set; } = default!;
        public string PasswordHash { get; private set; } = default!;
        public Enums.Role Role { get; private set; } = Enums.Role.Passenger;
        public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
        private User() { }
        public User(string fullName, string email, string phone, string passwordHash, Enums.Role role = Enums.Role.Passenger)
        {
            FullName = fullName; Email = email; Phone = phone; PasswordHash = passwordHash; Role = role;
        }
    }
}