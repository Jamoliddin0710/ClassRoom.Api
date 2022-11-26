using System.ComponentModel.DataAnnotations;

namespace ClassRoom.Model
{
    public class UserDto
    {
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
