using Infrastructure.Models;

namespace Application.Models.Booking
{
    public class BookingInputDto
    {
        public required int IdRoom { get; set; }
        public required DateTime Date { get; set; }
        public required int CheckInTimeId { get;set;}

        public Guid UserGuid { get; set; }

        public static implicit operator Bookings(BookingInputDto dto)
        {
            return new Bookings() { IdRoom = dto.IdRoom, DateReserved = dto.Date, CheckInTimeId = dto.CheckInTimeId, UserGuid = dto.UserGuid };
        }
        public override string ToString()
        {
            return string.Format("IdRoom: {0}, Date {1}, TimeId {2}", IdRoom, Date, CheckInTimeId);
        }
    }
}