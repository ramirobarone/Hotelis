namespace Application.Models.Users
{
    public record UserLoginDto (string FullName, string token, int RolId, Guid userGuid);
}
