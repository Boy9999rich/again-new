using _2_6_lesson.DataAccess.Entity;
using _2_6_lesson.Repositories;
using _2_6_lesson.Services.Dto;

namespace _2_6_lesson.Services;

public class UserService : IuserService
{
    private readonly IUserRepository _userRepository;

    public UserService()
    {
        _userRepository = new UserRepository();
    }

    private User ConvertToUserEntity(UserCreateDto dto)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Age = dto.Age,
            Email = dto.Email,
            Password = dto.Password,
        };
        return user;
    }

    private User ConvertToUser(UserUpdateDto dto)
    {
        var user = new User()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Age = dto.Age,
            Email = dto.Email,
            Password = dto.Password,
        };
        return user;
    }

    private UserGetDto ConvertToDto(User user)
    {
        var dto = new UserGetDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Age = user.Age,
            Email = user.Email,
        
        };
        return dto;
    }

    public UserGetDto AddUser(UserCreateDto dto)
    {
        var cheackingEmail = _userRepository.checkEmailContains(dto.Email);
        if (!dto.Email.EndsWith("@gmail.com") || cheackingEmail)
        {
            return null;
        }
        var user = ConvertToUserEntity(dto);
        var UserFromDb = _userRepository.WriteUser(user);
        var userDto = ConvertToDto(UserFromDb);
        return userDto;
    }


    public bool UserDelete(Guid id)
    {
        var result = _userRepository.DeleteUser(id);
        return result;
    }


    public bool UserUpdate(UserUpdateDto userUpdateDto)
    {
        var user = ConvertToUser(userUpdateDto);
        var result = _userRepository.UpdaterUser(user);
        return result;
    }

    public List<UserGetDto> GetUsers()
    {
        var users = _userRepository.ReadUsers();
        var userGetDto = new List<UserGetDto>();
        foreach (var user in users)
        {
            userGetDto.Add(ConvertToDto(user));
        }
        return userGetDto;
    }


    //    private readonly IUserRepository _userRepository;

    //    public UserService()
    //    {
    //        _userRepository = new UserRepository();
    //    }

    //    public UserGetDto AddUser(UserCreateDto dto)
    //    {
    //        var checkingEmail = _userRepository.checkEmailContains(dto.Email);
    //        if (!dto.Email.EndsWith("@gmail.com") || checkingEmail)
    //        {
    //            return null;
    //        }
    //        var user = ConvertToUserEntity(dto);
    //        var userFromDb = _userRepository.WriteUser(user);
    //        var userDto = ConvertToDto(userFromDb);
    //        return userDto;
    //    }

    //    public bool DeleteUser(Guid id)
    //    {
    //        var result = _userRepository.DeleteUser(id);
    //        return result;
    //    }

    //    public List<UserGetDto> GetUsers()
    //    {
    //        var users = _userRepository.ReadUsers();
    //        var usersGetDto = new List<UserGetDto>();
    //        foreach (var user in users)
    //        {
    //            usersGetDto.Add(ConvertToDto(user));
    //        }
    //        return usersGetDto;

    //    }

    //    public bool UpdateUser(UserUpdateDto userUpdateDto)
    //    {
    //        var user = ConvertToUser(userUpdateDto);
    //        var result = _userRepository.UpdaterUser(user);
    //        return result;
    //    }

    //    private User ConvertToUserEntity(UserCreateDto dto)
    //    {
    //        var user = new User()
    //        {
    //            Id = Guid.NewGuid(),
    //            FirstName = dto.FirstName,
    //            LastName = dto.LastName,
    //            Age = dto.Age,
    //            Email = dto.Email,
    //            Password = dto.Password,
    //        };
    //        return user;
    //    }

    //    private User ConvertToUser(UserUpdateDto dto)
    //    {
    //        var user = new User()
    //        {
    //            Id = dto.Id,
    //            FirstName = dto.FirstName,
    //            LastName = dto.LastName,
    //            Age = dto.Age,
    //            Email = dto.Email,
    //            Password = dto.Password,
    //        };
    //        return user;
    //    }

    //    private UserGetDto ConvertToDto(User user)
    //    {
    //        var dto = new UserGetDto()
    //        {
    //            Id = user.Id,
    //            FirstName = user.FirstName,
    //            LastName = user.LastName,
    //            Age = user.Age,
    //            Email = user.Email,
    //        };
    //        return dto;
    //    }


}
