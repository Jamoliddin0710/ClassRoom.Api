using ClassRoom.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = ClassRoom.Entities.Task;

namespace ClassRoom.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserCourse> userCourses { get; set; }
        public DbSet<UserTask> UserTask { get; set; }
        public DbSet<Task> Tasks { get; set; }
        
    }
}
