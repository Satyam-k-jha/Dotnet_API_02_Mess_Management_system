namespace MessManagementSystem.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }      
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Boolean IsActive { get; set; } = true;
        public String? Role { get; set; }
        public String? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
