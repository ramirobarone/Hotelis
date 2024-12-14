using Application.Interfaces;
using Application.Models;
using Application.Models.Booking.Available;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Application.Services.Rooms
{
    public class ServiceRoom(IRepository<Room> repositoryRoom,
        IRepository<Bookings> repositoryBooking,
        IRepository<TimesAvailable> repositoryTimes,
        ILogger<ServiceRoom> logger) : IServiceGeneric<RoomDto>, IServiceAvailable, ITimeRoom
    {
        public Task<RoomDto> Create(RoomDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<RoomDto>> GetAllById(int entity)
        {
            logger.LogInformation("Method Name {GetAllById} - Parameter: {entity}", nameof(GetAllById), entity);

            IEnumerable<Room> rooms = await repositoryRoom.GetAllByIdAsync(x => x.Hotels.Id == entity, null, z => z.Include(x => x.RoomPictures).Include(x => x.Cost));

            IList<RoomDto> roomsResult = new List<RoomDto>();

            foreach (Room room in rooms)
            {
                roomsResult.Add((RoomDto)room);
            }

            logger.LogInformation("Method Name {GetAllById} -  Parameter: {entity} - Result: {roomsResult}", nameof(GetAllById), entity, System.Text.Json.JsonSerializer.Serialize(roomsResult));

            return roomsResult;
        }

        public Task<RoomDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsAvailable(AvailableRequestDto availableDto) => await repositoryBooking
                .GetByIdAsync(x => x.IdRoom == availableDto.idRoom
                && x.CheckInTime.Id == availableDto.idCheckTime
                && x.DateReserved == availableDto.date) != null;
        
        public async Task<IEnumerable<ScheduleDto>> GetTimesAsync()
        {
            IList<ScheduleDto> times = new List<ScheduleDto>();

           var response = await repositoryTimes.GetAllByIdAsync(x => x.Id >= 0);

            foreach (TimesAvailable time in response)
            {
                times.Add(new ScheduleDto(time.Id, time.Time));
            }
            return times;
        }

        public Task Update(RoomDto entity)
        {
            throw new NotImplementedException();
        }
    }
}