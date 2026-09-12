using Microsoft.AspNetCore.Identity;
using WebApplication1.Core.Domain;
using WebApplication1.Core.Interfaces;
using WebApplication1.DTO;

namespace WebApplication1.Infrastructure.Auth
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher<User> _hasher;
        private readonly JwtService _jwtService;

        public AuthService(IUserRepository userRepository, PasswordHasher<User> hasher, JwtService jwtService)
        {
            _userRepository = userRepository;
            _hasher = hasher;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDTO?> RegisterAsync(LoginDTO dto)
        {
            bool emailTaken = await _userRepository.UserExistsAsync(dto.Email);

            if (emailTaken)
                return null;

            var user = new User
            {
                Email = dto.Email
            };

            user.PasswordHash = _hasher.HashPassword(user, dto.Password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDTO { Token = token, Email = user.Email };
        }

        public async Task<AuthResponseDTO?> LoginAsync(LoginDTO dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if (user == null)
                return null;

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
                return null;

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDTO { Token = token, Email = user.Email };
        }
    }
}
