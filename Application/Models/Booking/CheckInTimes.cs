namespace Application.Models.Booking
{
    public record class CheckInTimes(int Id, string CheckInTime)
    {
        public static implicit operator Application.Models.Booking.CheckInTimes(Infrastructure.Models.TimesAvailable input)
        {
            return new Application.Models.Booking.CheckInTimes(input);
        }
    }
}