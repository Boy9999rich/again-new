using _2_6_lesson.Services.Dto;

namespace _2_6_lesson.Services;

public interface IuserService
{

    UserGetDto AddUser(UserCreateDto dto);
    bool UserDelete(Guid id);
    bool UserUpdate(UserUpdateDto userUpdateDto);
    List<UserGetDto> GetUsers();

    //UserGetDto AddUser(UserCreateDto dto);
    //bool DeleteUser(Guid id);
    //bool UpdateUser(UserCreateDto userCreateDto);
    //List<UserGetDto> GetUsers();
}