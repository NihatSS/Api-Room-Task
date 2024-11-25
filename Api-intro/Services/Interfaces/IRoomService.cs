using Api_intro.DTOs.Rooms;

namespace Api_intro.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllAsync();
        Task<RoomDto> GetByIdAsync(int id);
        Task Create(RoomCreateDto room);
        Task Update(int id, RoomEditDto room);
        Task Delete(int id);
    }
}
