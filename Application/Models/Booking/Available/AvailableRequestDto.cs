namespace Application.Models.Booking.Available
{
    public record AvailableRequestDto(int idRoom, int idCheckTime, DateTime date);
    public class ScheduleDto
    {
        public ScheduleDto(int id, string inTime)
        {
            this.Id = id;
            this.InTime = inTime;
        }
        public int Id { get; init; }
        public string InTime { get; init; }


        public static implicit operator ScheduleDto(Infrastructure.Models.TimesAvailable checkInTimes)
        {
            return new ScheduleDto(checkInTimes.Id, checkInTimes.Time);
        }
    }
}
