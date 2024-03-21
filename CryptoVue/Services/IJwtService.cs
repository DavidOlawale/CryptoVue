using CryptoVue.Data.Models;

namespace CryptoVue.Services
{

    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}