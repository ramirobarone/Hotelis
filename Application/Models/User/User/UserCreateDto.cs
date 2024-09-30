using System.ComponentModel.DataAnnotations;

namespace Application.Models.User.User
{
    public class UserCreateDto : UserDto
    {
        public UserCreateDto(string name, string lastName, string codeArea, string phoneNumber, string identityNumber, string email, string password) : base(email, password)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            CodeArea = codeArea ?? throw new ArgumentNullException(nameof(codeArea));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            IdentityNumber = identityNumber ?? throw new ArgumentNullException(nameof(identityNumber));
        }

        [MinLength(3)]
        public required string Name { get; init; }
        [MinLength(3)]
        public required string LastName { get; init; }
        [MinLength(3)]
        public string CodeArea { get; init; }
        [MinLength(8)]
        public string PhoneNumber { get; init; }
        [MinLength(8)]
        public string IdentityNumber { get; init; }
    }
}
