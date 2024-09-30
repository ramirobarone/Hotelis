using Application.Exceptions;
using Application.Interfaces;
using Application.Models.Booking.Available;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Data.SqlTypes;

namespace Application.Services.Reserves
{
    public class BookingService(IRepository<Bookings> repositoryBookings,
        IRepository<Room> repositoryRoom,
        IRepository<TimesAvailable> repositorySchedule,
        ILogger<BookingService> logger) : IBookings, IServiceGeneric<Bookings>
    {
        public async Task<IEnumerable<ScheduleDto>> GetSchedulesyRoom(int _idRoom, string _date)
        {

            logger.LogInformation("parameters idRoom:{_idRoom} and date: {_date}", _idRoom, _date);

            DateTime date = Convert.ToDateTime(_date);

            List<ScheduleDto>? result = new List<ScheduleDto>();

            IEnumerable<Bookings> _bookings = await repositoryBookings.GetAllByIdAsync(x => x.IdRoom == _idRoom
            && x.DateReserved == date,
             orderBy: null,
             include: z => z.Include(x => x.CheckInTime));

            int[] idsSchedulesReserved = _bookings.Select(x => x.CheckInTime.Id).ToArray();

            IEnumerable<TimesAvailable>? schedules = await repositorySchedule.GetAllByIdAsync(x => !idsSchedulesReserved.Contains(x.Id));

            foreach (TimesAvailable schedule in schedules)
            {
                result.Add(schedule);
            }

            return result;
        }

        public async Task<Bookings> Create(Bookings booking)
        {
            EntityEntry<Bookings>? bookingSaved = null;

            ArgumentNullException.ThrowIfNull(booking, nameof(booking));

            if (await ExistBooking(booking))
                throw new BookingException("Hay una reserva para ese dia y hora");

            Room resultRoom = await GetRoomWithCost(booking.IdRoom);

            if (RoomIsNotNullOrEmpty(resultRoom))
                bookingSaved = await repositoryBookings.CreateAsync(booking);

            logger.LogInformation($"Bookings created: {booking.Id}");

            return bookingSaved?.Entity is null ? throw new Exception("No se guardo la reserva") : bookingSaved.Entity;
        }

        private async Task<Room> GetRoomWithCost(int idRoom) => await repositoryRoom.GetByIdAsync(x => x.Id == idRoom, y => y.Include(y => y.Cost));

        private bool RoomIsNotNullOrEmpty(Room room) => room is not null;

        private async Task<bool> ExistBooking(Bookings booking) => await repositoryBookings.Exist(x => x.IdRoom == booking.IdRoom
                                                                                                  && x.CheckInTimeId == booking.CheckInTimeId
                                                                                                  && x.DateReserved == booking.DateReserved);

        public async Task Delete(int id) => await repositoryBookings.DeleteAsync(id);
        public async Task<Bookings> GetById(int id) => await repositoryBookings.GetByIdAsync(x => x.Id == id);

        public async Task<IEnumerable<Bookings>> GetAllById(int entity)
        {
            if (entity == 0)
                throw new ArgumentNullException(nameof(entity));

            return await repositoryBookings.GetAllByIdAsync(x => x.IdRoom == entity);
        }

        public async Task Update(Bookings entity)
        {
            logger.LogInformation($"Updated {entity}");

            await repositoryBookings.UpdateAsync(entity);
        }
    }
}