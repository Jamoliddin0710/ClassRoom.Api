using ClassRoom.Entities;
using ClassRoom.Model;
using ClassRotom.Mapper;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Task = ClassRoom.Entities.Task;

namespace ClassRoom.Controllers;

public partial class CourseController : ControllerBase
{
    [HttpPost("courseId{courseId}/add-task")]
    public async Task<IActionResult> AddTask(Guid courseId, CreateTaskDto createTaskDto)
    {
        var user = await _userManager.GetUserAsync(User);
        var course = await _context.Courses.FirstOrDefaultAsync(course => course.Id == courseId);
        if (course is null)
        {
            return NotFound("course topilmadi");
        }
        if (!course.Users.Any(usercourse => usercourse.UserId == user.Id))
        {
            return NotFound("user coursega qo'shilmagan");
        }
        var task = createTaskDto.Adapt<Task>();
        task.CourseId = course.Id;
        task.CreatedDate = DateTime.Now;
        course.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("gettask/courseId{courseId}")]
    public async Task<IActionResult> GetTasks(Guid courseId)
    {
        var user = await _userManager.GetUserAsync(User);
        var course = await _context.Courses.FirstOrDefaultAsync(course => course.Id == courseId);
        if (course is null)
        {
            return NotFound("course is null");
        }

        if (!course.Users.Any(usercourse => usercourse.UserId == user.Id && usercourse.IsAdmin))
        {
            return NotFound("user is not admin");
        }
        var task = course.Tasks.Select(task => task.Adapt<TaskDto>()).ToList();
        return Ok(task);
    }

    [HttpGet("gettask/courseId{courseId},taskId{taskId}")]
    public async Task<IActionResult> GetTaskById(Guid courseId, Guid taskId)
    {
        // user adminligini tekshirish kerak
        var user = await _userManager.GetUserAsync(User);

        var course = await _context.Courses.FirstOrDefaultAsync(course => course.Id == courseId);
        if (course is null)
        {
            return NotFound("course is null");
        }

        if (!course.Users.Any(usercourse => usercourse.UserId == user.Id && usercourse.IsAdmin))
        {
            return NotFound("user is not admin");
        }


        var task = await _context.Tasks.FirstOrDefaultAsync(task => task.Id == taskId && task.CourseId == courseId);
        if (task is null)
        {
            return NotFound("task is not found");
        }

        return Ok(task);
    }

    [HttpPut("updatetask/courseId{courseId} , taskId{taskId}")]
    public async Task<IActionResult> UpdateTaskAsync(Guid courseId, Guid taskId, UpdateTaskDto updateTaskDto)
    {
        var user = await _userManager.GetUserAsync(User);

        var course = await _context.Courses.FirstOrDefaultAsync(course => course.Id == courseId);
        if (course is null)
        {
            return NotFound("course is null");
        }

        if (!course.Users.Any(usercourse => usercourse.UserId == user.Id && usercourse.IsAdmin))
        {
            return NotFound("user is not admin");
        }
        var task = await _context.Tasks.FirstOrDefaultAsync(task => ((task.CourseId == courseId) && (task.Id == taskId)));
        task.SetValue(updateTaskDto);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("Delete/courseId{courseId},taskId{taskId}")]
    public async Task<IActionResult> DeleteTask(Guid courseId, Guid taskId)
    {
        var user = await _userManager.GetUserAsync(User);

        var course = await _context.Courses.FirstOrDefaultAsync(course => course.Id == courseId);
        if (course is null)
        {
            return NotFound("course is null");
        }

        if (!course.Users.Any(usercourse => usercourse.UserId == user.Id && usercourse.IsAdmin))
        {
            return NotFound("user is not admin");
        }
        if (!course.Tasks.Any(task => (task.CourseId == courseId) && (task.Id == taskId)))
            return NotFound("task is not exists");

        var task = course.Tasks.FirstOrDefault(task => (task.CourseId == courseId) && (task.Id == taskId));
        course.Tasks.Remove(task);

        return Ok();
    }
    // Model Dto qo'shishdan maqsad loop bo'lib qolishini  oldini  oladi 

    [HttpPut("course/{courseId}/task/{taskId}/{usertaskId}/update/task")]
    public async Task<IActionResult> UpdateUserTaskResultDto(Guid courseId, Guid taskId, Guid usertaskId, CreateUserTaskResultDto userTaskResultDto)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(task => task.Id == taskId && task.CourseId == courseId);
        if (task is null)
            return NotFound();
        var usertask = task.UserTasks.FirstOrDefault(usertask => usertask.Id == usertaskId);
        if (usertask is null)
        {
            return NotFound("user task is not found");
        }
        usertask.Description = userTaskResultDto.Description;
        usertask.Status = userTaskResultDto.Status;
        _context.SaveChanges();
        return Ok();
    }


 
}

      
    


