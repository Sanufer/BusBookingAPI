namespace BusBooking.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid TripId { get; private set; }
        public Guid UserId { get; private set; }
        private readonly List<string> _seatNumbers = new();
        public IReadOnlyCollection<string> SeatNumbers => _seatNumbers;
        public decimal TotalAmount { get; private set; }
        public Enums.BookingStatus Status { get; private set; } = Enums.BookingStatus.Pending;
        public DateTimeOffset BookingDate { get; private set; } = DateTimeOffset.UtcNow;
        public string? PaymentTxnId { get; private set; }
        public long Version { get; set; } // optimistic concurrency

        private Booking() { }
        public Booking(Guid tripId, Guid userId, IEnumerable<string> seats, decimal totalAmount)
        {
            TripId = tripId; UserId = userId; _seatNumbers = seats.ToList(); TotalAmount = totalAmount;
        }
        public void MarkConfirmed(string txnId) { Status = Enums.BookingStatus.Confirmed; PaymentTxnId = txnId; }
        public void MarkCancelled() { Status = Enums.BookingStatus.Cancelled; }
    }
}