namespace BusBooking.Application.DTOs.BusOperator
{
    public class CreateBusOperatorDto
    {
        public string Name { get; set; } = default!;
        public string ContactEmail { get; set; } = default!;
        public string ContactPhone { get; set; } = default!;
    }
}