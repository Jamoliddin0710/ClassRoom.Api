using ClassRoom.Entities;
using ClassRoom.Model;
using Mapster;

namespace ClassRoom.Mapper;
  public static class CourseMapper
    {
        public static CourseDto ToDto (this Course course)
        {


         return  new CourseDto()
            {
                Id = course.Id,
                Name = course.Name,
                Key = course.Key,
                Users = course.Users.Select(usercourse => usercourse.User.Adapt<UserDto>()).ToList(),
            };
        }
    }


