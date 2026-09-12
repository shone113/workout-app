using WebApplication1.DTO;

namespace WebApplication1.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO?> RegisterAsync(LoginDTO dto);
        Task<AuthResponseDTO?> LoginAsync(LoginDTO dto);
    }
}
