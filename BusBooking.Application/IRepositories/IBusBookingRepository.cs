public interface IBusBookingRepository<T>where T : class
{
    Task<T> GetRecordByIdAsync(Guid guid);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T dbRecord);
    Task UpdateAsync(T dbRecord);
    Task DeleteAsync(T dbRecord);
}