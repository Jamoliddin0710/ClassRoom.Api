using ClassRoom.Entities;
using System.Threading.Tasks;

namespace ClassRoom.Model
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxScore { get; set; }
        public EUserStatus Status { get; set; }
    }
}