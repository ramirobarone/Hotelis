namespace Infrastructure.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? IdAddress { get; set; }
        public string? CodeArea { get; set; }    
        public string? PhoneNumber { get; set; }
        public required string IdentityNumber { get; set; }

        public virtual Address? Address { get; set; }

    }
}
