using Application.Models.Booking.Available;
using Infrastructure.Models;

namespace Application.Interfaces
{
    public interface IBookings
    {
        Task<IEnumerable<ScheduleDto>> GetSchedulesyRoom(int _idRoom, string _date);
        Task<IEnumerable<Bookings>> GetBookingsByUserGuidAsync(Guid userGuid);
    }
}
