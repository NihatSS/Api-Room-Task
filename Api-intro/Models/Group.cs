namespace Api_intro.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int? RoomId { get; set; }
        public Room Room { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<GroupStudents> StudentGroups { get; set; }
    }
}
