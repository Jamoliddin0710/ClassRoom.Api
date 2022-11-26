using ClassRoom.Entities;
using ClassRoom.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ClassRoom.Controllers
{
    public partial class CourseController : ControllerBase
    {
        [HttpGet("task/comment/courseId{courseId}taskId{taskId}/get/comment")]
        public async Task<IActionResult> GetTaskComment(Guid courseId , Guid taskId )
        {

            var task = await _context.Tasks.FirstOrDefaultAsync(task => task.Id == taskId && task.CourseId == courseId);
            if(task is null)
            {
                return NotFound("task is null");
            }

            var comments = new List<TaskCommentDto>();
           if(task.TaskComments is null)
            {
                return Ok(comments);
            }
            
            var maincomment = task.TaskComments.Where(task => task.ParentId == null).ToList();
            // maincomment bu commentlarni parenti yo'gini oladi
            // agar maincomment bu parentId null degani u asossiy comment degani asosiy
            // commentni ham childrenlari bo'ladi
            foreach(var taskComment in task.TaskComments)
            {
                var commentdto = ToTaskCommentDto(taskComment);
               
                comments.Add(commentdto);

            };

            return Ok();
        }
        // recursive function
        private TaskCommentDto ToTaskCommentDto(TaskComment comment)
        {
            //commentni commentdtoga o'zlashtiradi bundan maqasad shuki bu ish amalga oshirilmas loop muammo chiqarishi mumkin
          // rekursiv functionnni vazifasi commentni hamma commentlarini olib beradi 
            var commentdto = new TaskCommentDto()
            {
                Id = comment.Id,
                Comment = comment.Comment,
                CreateDate = comment.CreatedDate,
                User = comment.User?.Adapt<UserDto>(),
            };
            if (commentdto.Children is null)
                return commentdto;
            foreach(var child in comment.Children)
            {
                commentdto.Children ??= new List<TaskCommentDto>();
                commentdto.Children.Add(ToTaskCommentDto(child));
            }

            return commentdto;
        }

        [HttpPost("course/{courseId}/task{taskId}/add-comment")]
        public async Task<IActionResult> AddTaskComment(Guid courseId , Guid taskId , CreateTaskCommentDto taskCommentDto)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(task => task.CourseId == courseId && task.Id == taskId);
            if(task is null)
            {
                return NotFound("task is not found");
            }
            var user = await _userManager.GetUserAsync(User);

            task.TaskComments ??= new List<Entities.TaskComment>();
            task.TaskComments.Add(
                new Entities.TaskComment()
                {
                    TaskId = task.Id,
                    UserId = user.Id,
                    ParentId = taskCommentDto.ParentId,
                    Comment = taskCommentDto.Comment,
                });
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}


//get taskcomment
//add task comment