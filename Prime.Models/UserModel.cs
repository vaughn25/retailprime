
namespace Prime.Models
{
    public record UserDTO(string Username, string Password);

    /// <summary>
    /// This model defines a user in Retail Prime.
    /// </summary>
    public class UserModel
    {
        public int Id { get; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; init; }
        public required DateTime CreatedAt { get; init; }
        public DateTime? LastLogin { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
