using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusBooking.Infrastructure.Data
{
    public class BusBookingDbContext : DbContext
    {
        public BusBookingDbContext(DbContextOptions<BusBookingDbContext> options) : base(options)
        {
        }

        // DbSet properties for your entities go here, e.g.:
        public DbSet<User> Users { get; set; }
        public DbSet<BusOperator> BusOperators { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity mappings here
        }
    }
}