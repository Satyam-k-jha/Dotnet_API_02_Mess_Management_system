using AutoMapper;
using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Repositories.Interfaces;
using MessManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MessManagementSystem.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IStudentService studentService;
        //private readonly IStudentRepository studentRepository;

        public AuthService(AppDbContext context, IMapper mapper, IConfiguration configuration, IStudentService studentService)
        {
            this.context = context;
            this.mapper = mapper;
            this.configuration = configuration;
            this.studentService = studentService;
            //this.studentRepository = studentRepository;
        }
        public async Task<TokenResponseDto?> LoginUserAsync(LoginUserDto request)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);
            if (user == null)
            {
                return null;
            }
            else if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }
            TokenResponseDto response = await CreateTokenResponse(user);
            return response;

        }

        private async Task<TokenResponseDto> CreateTokenResponse(User user)
        {
            return new TokenResponseDto
            {
                AccessToken = CreateToken(user),
                RefreshToken = await GenerateAndSaveRefreshTokenAsync(user)
            };
        }

        public async Task<ResponseUserDto?> RegisterUserAsync(RegisterUserDto request)
        {
            User user = await context.Users
                .FirstOrDefaultAsync(u => u.UserName == request.UserName);

            if (user != null)
            {
                return null;
            }

            user = new User();

            string hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.UserName = request.UserName;
            user.PasswordHash = hashedPassword;
            user.Role = request.Role;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();   // User.Id is generated here

            if (user.Role == "Student")
            {
                AddStudentDto student = new AddStudentDto
                {
                    Name = user.UserName,
                    UserId = user.Id
                };

                await studentService.AddStudentAsync(student);
            }

            return mapper.Map<ResponseUserDto>(user);
        }
        public async Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request)
        {
            var user = await ValidateRefreshTokenAsync(request.UserId, request.RefreshToken);
            if(user == null)
            {
                return null;
            }
            return await CreateTokenResponse(user);
        }

        private async Task<User?> ValidateRefreshTokenAsync(Guid userId, String refreshToken)
        {
            var user = await context.Users.FindAsync(userId);
            if(user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return null;
            }
            return user;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<String> GenerateAndSaveRefreshTokenAsync(User user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await context.SaveChangesAsync();
            return refreshToken;
        }


        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            //Console.WriteLine(key);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }

    }
}
