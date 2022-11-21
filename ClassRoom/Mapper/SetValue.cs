using ClassRoom.Model;

namespace ClassRotom.Mapper
{
    public static class TaskMapper
    {
        public static void SetValue(this ClassRoom.Entities.Task task , UpdateTaskDto updateTaskDto)
        {
            task.Title = updateTaskDto.Title;
            task.Status = updateTaskDto.Status;
            task.Description = updateTaskDto.Description;
            task.MaxScore = updateTaskDto.MaxScore;
            task.StartDate = updateTaskDto.StartDate;
            task.EndDate = updateTaskDto.EndDate;
        }
    }
}
