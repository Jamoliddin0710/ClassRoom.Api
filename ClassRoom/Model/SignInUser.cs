using System.ComponentModel.DataAnnotations;

namespace ClassRoom.Model
{
    public class SignInUser
    {
        [Required]
        public string? UserName { get; set; }
      
        [Required]
        public string? Password { get; set; }
    }
}
