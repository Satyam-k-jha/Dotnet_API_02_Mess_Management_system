namespace MessManagementSystem.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }      
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Boolean IsActive { get; set; } = true;
        public string Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public Student? Student { get; set; }
    }
}
