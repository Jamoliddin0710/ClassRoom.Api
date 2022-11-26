using ClassRoom.Context;
using ClassRoom.Entities;
using ClassRoom.Mapper;
using ClassRoom.Migrations;
using ClassRoom.Model;
using ClassRotom.Mapper;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        public ProfileController(UserManager<User> userManager , AppDbContext appDbContext)
        {
            _userManager = userManager;
            _context = appDbContext;
        }
        [HttpGet("get/user/course")] // userga tegishli hamma kurslarni chiqaradi 
        public async Task<IActionResult> GetUserCourse()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user is null)
            {
                return NotFound("user is null");
            }
            var coursesDto = user.Courses.Select(course => course.Course.ToDto()).ToList();
            
 
            return Ok(coursesDto ?? new List<CourseDto>());
        }

        [HttpGet("get/user/course/task")] // userga tegishli hamma tasklarni chiqaradi
        public async Task<IActionResult> GetUserTask(Guid courseId)
        {
            var user = await _userManager.GetUserAsync(User);
            if(user is null)
            {
                return NotFound("user is null");
            }
            var usercourse = user.Courses.FirstOrDefault(usercourse=>usercourse.CourseId == courseId);
            var tasks = usercourse.Course.Tasks.ToList();
            if(tasks is null)
            {
                return NotFound("task is not found");
            }
            var usertasks = new List<UserTaskResultDto>();
            foreach(var task in tasks)
            {
                var result = task.Adapt<UserTaskResultDto>();
                var resultentity = task.UserTasks.FirstOrDefault(task => task.UserId == user.Id);
                result.UserTaskResult = resultentity == null ? null : new UserTaskResult()
                {
                    Status = resultentity.Status,
                    Description = resultentity.Description,
                };
                
                usertasks.Add(result);

            }

            return Ok(usertasks);
        }

        [HttpPost("addressresult/courseId{courseId}/taskId{taskId}")]
        public async Task<IActionResult> GetAddresResult(Guid courseId, Guid taskId , CreateUserTaskResultDto resultTask)
        {
            var user =  await _userManager.GetUserAsync(User);
            var usertask = await _context.UserTask.
                FirstOrDefaultAsync(user => user.TaskId == taskId && user.UserId == user.Id);
            if(usertask is null)
            {
                usertask = new UserTask()
                {
                    UserId = user.Id,
                    TaskId = taskId
                };
                _context.UserTask.Add(usertask);
            }
            usertask.Status = resultTask.Status;
            usertask.Description = resultTask.Description;
            _context.SaveChanges();
            return Ok();
        }
    }
}
