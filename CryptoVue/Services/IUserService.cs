using CryptoVue.Data.Models;

namespace CryptoVue.Services
{
    public interface IUserService
    {
        User? GetUser(string username);
        bool VerifyPassword(string password, string passwordHash);
    }
}
