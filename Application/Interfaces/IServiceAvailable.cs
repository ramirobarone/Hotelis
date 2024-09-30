using Application.Models.Booking.Available;

namespace Application.Interfaces
{
    public interface IServiceAvailable
    {
        Task<bool> IsAvailable(AvailableRequestDto availableDto);
    }
}
