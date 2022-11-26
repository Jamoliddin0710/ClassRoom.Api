using System.ComponentModel.DataAnnotations;

namespace ClassRoom.Model
{
    public class CourseModel
    {
        [Required]
        public string Name { get; set; }
       
    }
}
