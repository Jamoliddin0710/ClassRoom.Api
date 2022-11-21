using ClassRoom.Entities;

namespace ClassRoom.Model
{
    public class UserTaskResultDto : CreateTaskDto
    {
        public UserTaskResult UserResult { get; set; }
    }
    public class UserTaskResult
    {
        public string Description { get; set; }
        public EUserStatus Status { get; set; }
    }
}
