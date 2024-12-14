namespace Application.Models.Booking.Available
{
    public record AvailableRequestDto(int idRoom, int idCheckTime, DateTime date);
    public class ScheduleDto(int Id, string InTime)
    {
        public int Id { get; } = Id;
        public string InTime { get; } = InTime;

        public static implicit operator ScheduleDto(Infrastructure.Models.TimesAvailable checkInTimes)
        {
            return new ScheduleDto(checkInTimes.Id, checkInTimes.Time);
        }
    }
}
