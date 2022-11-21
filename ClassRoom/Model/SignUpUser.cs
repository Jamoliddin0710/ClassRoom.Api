using System.ComponentModel.DataAnnotations;

namespace ClassRoom.Model
{
    public class SignUpUser
    {
        [Required]
        public string? UserName { get; set;}
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string? Password { get; set;}
        public string ConfirmPassword { get; set; }
    }
}
