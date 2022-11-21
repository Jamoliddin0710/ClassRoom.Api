using System.ComponentModel.DataAnnotations;

namespace ClassRoom.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string? Key { get; set;}
        public string? Name { get; set; }
        public virtual List<UserCourse> Users { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
