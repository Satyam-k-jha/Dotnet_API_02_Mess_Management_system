using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;

namespace MessManagementSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseUserDto?> RegisterUserAsync(RegisterUserDto request);
        Task<TokenResponseDto?> LoginUserAsync(LoginUserDto request);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
    }
}
