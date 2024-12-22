using _2_6_lesson.DataAccess.Entity;

namespace _2_6_lesson.Repositories
{
    public interface IUserRepository
    {
        User WriteUser(User user);
        bool DeleteUser(Guid id);
        bool UpdaterUser(User user);
        User ReadUserById(Guid id);
        List<User> ReadUsers();
        bool checkEmailContains(string email);

    }
}