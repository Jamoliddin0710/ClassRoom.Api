using System.ComponentModel.DataAnnotations;

namespace ClassRoom.Model
{
    public class TaskCommentDto
    {
        public Guid Id { get; set; }
        [Required]
        public string? Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public List<TaskCommentDto>? Children { get; set; }
        public UserDto? User { get; set; }
    }
}

