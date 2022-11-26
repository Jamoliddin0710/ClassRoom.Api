using System.ComponentModel.DataAnnotations;

namespace ClassRoom.Model
{
    public class CreateTaskCommentDto
    {
        [Required]
        public string? Comment { get; set; }
        public Guid ParentId { get; set; }
    }
}
