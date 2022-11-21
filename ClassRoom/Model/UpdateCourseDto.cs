using System.ComponentModel.DataAnnotations;

namespace ClassRoom.Model
{
    public class UpdateCourseDto
    {
        [Required]
        public string Name { get; set;}
    }
}
