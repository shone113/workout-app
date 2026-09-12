using WebApplication1.Core.Domain;

namespace WebApplication1.Core.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
