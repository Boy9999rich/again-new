using _2_6_lesson.DataAccess.Entity;
using System.Text.Json;

namespace _2_6_lesson.Repositories;

public class UserRepository : IUserRepository
{
    private string path;
    private List<User> _users;
    public UserRepository()
    {
        path = "../../../DataAccess/Data/user.json";
        _users = new List<User>();
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "[]");
        }
        else
        {
            _users = ReadUsers();
        }
    }
    public bool checkEmailContains(string email)
    {
        var users = ReadUsers();
        foreach (var user in users)
        {
            if (user.Email == email)
            {
                return true;
            }
        }
        return false;
    }

    public bool DeleteUser(Guid id)
    {
        var RemovingUser = ReadUserById(id);
        if (RemovingUser is null)
        {
            return false;
        }
        _users.Remove(RemovingUser);
        SaveData();
        return true;
    }

    public User ReadUserById(Guid id)
    {
        foreach (var user in _users)
        {
            if (user.Id == id)
            {
                return user;
            }
        }
        return null;
    }

    public List<User> ReadUsers()
    {
        var userJson = File.ReadAllText(path);
        var result = JsonSerializer.Deserialize<List<User>>(userJson);
        return result;
    }

    public bool UpdaterUser(User user)
    {
        var UpdatingUser = ReadUserById(user.Id);
        if (UpdatingUser is null)
        {
            return false;
        }
        var index = _users.IndexOf(user);
        _users[index] = user;
        SaveData();
        return true;
    }

    public User WriteUser(User user)
    {
        _users.Add(user);
        SaveData();
        return user;
    }
    private void SaveData()
    {
        var userJson = JsonSerializer.Serialize(_users);
        File.WriteAllText(path, userJson);
    }
}
