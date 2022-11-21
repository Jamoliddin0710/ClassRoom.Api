using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRoom.Entities
{
    public class UserCourse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid CourseId { get; set; }
        [ForeignKey("CourseId")]
        public bool IsAdmin { get; set; }
        public virtual Course Course { get; set; }
       // public object ToDto { get; internal set; }
    }
}
