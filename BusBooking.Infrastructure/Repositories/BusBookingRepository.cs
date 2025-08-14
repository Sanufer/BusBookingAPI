using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BusBooking.Infrastructure.Repositories
{
    public class BusBookingRepository<T> : IBusBookingRepository<T> where T : class
    {
        private readonly BusBookingDbContext _busBookingDbContext;
        public BusBookingRepository(BusBookingDbContext busBookingDbContext)
        {
            _busBookingDbContext = busBookingDbContext;
        }

        public async Task AddAsync(T dbRecord)
        {
            _busBookingDbContext.Set<T>().Add(dbRecord);
            await _busBookingDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _busBookingDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetRecordByIdAsync(Guid guid)
        {
            return await _busBookingDbContext.Set<T>().FindAsync(guid);
        }

        public Task UpdateAsync(T dbRecord)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T dbRecord)
        {
            throw new NotImplementedException();
        }
    }
}