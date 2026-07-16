namespace MessManagementSystem.Models.DTO
{
    public class RefreshTokenRequestDto
    {
        public Guid UserId { get; set; }
        public required String RefreshToken { get; set; }
    }
}
