using _2_6_lesson.Services;
using _2_6_lesson.Services.Dto;

namespace _2_6_lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IuserService userService = new UserService();
            var users = userService.GetUsers();

            UserCreateDto dto1 = new UserCreateDto()
            {
                FirstName = "ronaldo",
                LastName = "nnn",
                Age = 25,
                Email = "sssss@gmail.com",
                Password = "5555",
            };
            UserCreateDto dto2 = new UserCreateDto()
            {
                FirstName = "jjjjj",
                LastName = "jjjjj",
                Age = 24,
                Password = "99999",
                Email = "rich@gmail.com",
            };

            userService.AddUser(dto1);
            userService.AddUser(dto2);
        }
    }
}
