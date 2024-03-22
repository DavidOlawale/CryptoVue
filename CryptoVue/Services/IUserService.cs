using CryptoVue.Data.Models;

namespace CryptoVue.Services
{
    public interface IUserService
    {
        User? GetUser(string username);
        bool IsAuthenticated(string password, string passwordHash);
    }
}
