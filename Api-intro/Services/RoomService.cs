using Api_intro.Data;
using Api_intro.DTOs.Rooms;
using Api_intro.Helpers.Exceptions;
using Api_intro.Models;
using Api_intro.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_intro.Services
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RoomService(AppDbContext context,
                           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Create(RoomCreateDto room)
        {
            await _context.Rooms.AddAsync(_mapper.Map<Room>(room));
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Room room = await _context.Rooms.AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.Id == id)
                                                ?? throw new NotFoundException("Room not found");

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<RoomDto>>( await _context.Rooms.Include(x=>x.Groups)
                                                                          .AsNoTracking()
                                                                          .ToListAsync());
        }

        public async Task<RoomDto> GetByIdAsync(int id)
        {
            Room room = await _context.Rooms.AsNoTracking()
                                            .FirstOrDefaultAsync(x=>x.Id == id)
                                                ?? throw new NotFoundException("Room not found");
            return _mapper.Map<RoomDto>(room);
        }

        public async Task Update(int id, RoomEditDto room)
        {
            Room existRoom = await _context.Rooms.AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.Id == id)
                                                ?? throw new NotFoundException("Room not found");

            _mapper.Map(existRoom, room);
            _context.Rooms.Update(existRoom);
            await _context.SaveChangesAsync();
        }
    }
}
