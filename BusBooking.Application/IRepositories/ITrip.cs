using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Domain.Entities;

namespace BusBooking.Application.IRepositories
{
    public interface ITrip : IBusBookingRepository<Trip>
    {
        
    }
}