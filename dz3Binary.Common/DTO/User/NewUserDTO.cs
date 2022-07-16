namespace dz3Binary.Common.DTO.User;

public record NewUserDTO
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public DateTime RegisteredAt { get; init; }
    public DateTime BirthDay { get; init; }
}
