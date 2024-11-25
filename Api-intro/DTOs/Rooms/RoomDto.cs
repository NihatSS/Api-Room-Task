using Api_intro.Models;

namespace Api_intro.DTOs.Rooms
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
