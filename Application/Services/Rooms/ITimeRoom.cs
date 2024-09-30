using Application.Models.Booking.Available;

namespace Application.Services.Rooms
{
    public interface ITimeRoom
    {
        Task<IEnumerable<ScheduleDto>> GetTimesAsync();
    }
}