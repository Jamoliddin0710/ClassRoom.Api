using ClassRoom.Entities;

namespace ClassRoom.Model
{
    public class UserTaskResultDto : TaskDto
    {
        public UserTaskResult? UserTaskResult { get; set; }
    }
    public class UserTaskResult
    {
        public string? Description { get; set; }
        public EUserTaskStatus Status { get; set; }
    }
}
