namespace Api_intro.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
