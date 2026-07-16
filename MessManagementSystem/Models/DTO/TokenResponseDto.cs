namespace MessManagementSystem.Models.DTO
{
    public class TokenResponseDto
    {
        public required String AccessToken { get; set; }
        public required String RefreshToken { get; set; }
    }
}
