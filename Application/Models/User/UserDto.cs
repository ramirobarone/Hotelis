using System.ComponentModel.DataAnnotations;

namespace Application.Models.User
{
    public class UserDto
    {
        public UserDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
        [StringLength(100), MinLength(10), RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$")]
        public required string Email { get; init; }
        
        [DataType(DataType.Password)]
        [MinLength(8)]
        public required string Password { get; init; }
    }
}
