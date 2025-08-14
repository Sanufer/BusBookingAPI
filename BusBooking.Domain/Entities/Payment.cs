namespace BusBooking.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid BookingId { get; private set; }
        public decimal Amount { get; private set; }
        public Enums.PaymentStatus Status { get; private set; } = Enums.PaymentStatus.Initiated;
        public string? TransactionId { get; private set; }
        public DateTimeOffset PaymentDate { get; private set; } = DateTimeOffset.UtcNow;
        private Payment() { }
        public Payment(Guid bookingId, decimal amount) { BookingId = bookingId; Amount = amount; }
        public void MarkPaid(string txn) { Status = Enums.PaymentStatus.Paid; TransactionId = txn; }
        public void MarkFailed() { Status = Enums.PaymentStatus.Failed; }
    }
}