namespace _2_6_lesson.Services.Dto;

public class UserUpdateDto : UserBaseDto
{
    public Guid Id { get; set; }
    public string Password { get; set; }
}
