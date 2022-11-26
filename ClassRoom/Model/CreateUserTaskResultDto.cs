using ClassRoom.Entities;

namespace ClassRoom.Model
{
    public class CreateUserTaskResultDto
    {
        public string? Description { get; set; }
        public EUserTaskStatus Status { get; set; }
    }
}