namespace BusBooking.Domain.Enums
{
    public enum Role { Passenger = 0, Operator = 1, Admin = 2 }
    public enum BookingStatus { Pending = 0, Confirmed = 1, Cancelled = 2, Expired = 3 }
    public enum PaymentStatus { Initiated = 0, Paid = 1, Failed = 2, Refunded = 3 }
    public enum BusType { Seater = 0, Sleeper = 1, AC = 2, NonAC = 3 }
}