using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRoom.Entities
{
    public class TaskComment
    {
        public Guid Id { get; set; }
        [Required]
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid? TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual Task? Task { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
        public Guid? ParentId { get; set; }
        public virtual TaskComment? Parent { get; set; }
        public virtual List<TaskComment>? Children { get; set; }
    }
}
