using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRoom.Entities
{
    public class UserTask
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("CourseId")]
        public virtual User? User { get; set; }
        public Guid TaskId { get; set; }
        [ForeignKey("TaskId")]
        public virtual Task? Task { get; set; }
        public string Description { get; set; }
        public EUserStatus Status { get; set; }

        }
    }
