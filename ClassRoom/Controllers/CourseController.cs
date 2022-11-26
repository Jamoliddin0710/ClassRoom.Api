using ClassRoom.Context;
using ClassRoom.Entities;
using ClassRoom.Model;
//using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassRoom.Mapper;
namespace ClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CourseController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public CourseController(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("get-courses")]
        public async Task<IActionResult> GetCourse()
        {
               var courses = await _context.Courses.ToListAsync();
                List<CourseDto> courseDtos = courses.Select(c=>c.ToDto()).ToList();
               return Ok(courseDtos);
        }

        [HttpGet("GetCoursesById{id}")]
        public async  Task<IActionResult> GetCourseById(Guid id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course is null)
                return NotFound();


            return Ok(course.ToDto());
        }

        [HttpPost("create-course")]
        public async Task<IActionResult> CreateCourse([FromBody]CourseModel courseModel)
        {
           var user = await _userManager.GetUserAsync(User);

          if(user == null)
            {
                return NotFound();
            }
            var course = new Course()
            {
                Key = Guid.NewGuid().ToString("N"),
                Name = courseModel.Name,
                Users = new List<UserCourse>()
                    {
                        new UserCourse()
                        {
                            
                            UserId = user.Id,
                            IsAdmin = true,
                        }
                    }
            };
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
           
            
            return Ok(course.ToDto());
        }

        [HttpPut("UpdateCourse{id}")]
        public async Task<IActionResult> UpdateCourse(Guid id ,[FromBody] UpdateCourseDto updateCourseDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var course = await _context.Courses.FindAsync(id);
            if(course == null)
                return NotFound();
            course.Name = updateCourseDto.Name;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);
            if(course is null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(User);

            if(!course.Users.Any(u => u.UserId == user.Id && u.IsAdmin) == true)
            {
                return Forbid();
            }
            
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{courseId}/join-course")]
        public async Task<IActionResult> JoinTasks(Guid courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(course => course.Id == courseId);
            if(course is null)
            {
                return NotFound("kurs topilmadi");
            }

            var user = await _userManager.GetUserAsync(User);
            if(user is null)
            {
                return NotFound("user ro'yxatdan o'tmagan");
            }

            var usercourse = new UserCourse()
            {
                UserId = user.Id,
                CourseId = course.Id,
                IsAdmin = false
            };
            if(course.Users.Any(usercourse=>usercourse.UserId == user.Id))
            {
                return NotFound("user bu kursda mavjud");
            }
            course.Users.Add(usercourse);
            _context.SaveChanges();
            return Ok();
        }
    }
}
