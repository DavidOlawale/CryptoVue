using CryptoVue.Data;
using CryptoVue.Data.Models;

namespace CryptoVue.Services.Implementation
{
    public class UserService: IUserService
    {
        private readonly List<User> _users;
        private readonly CryptoVueDbContext _dbContext;

        public UserService(CryptoVueDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public User? GetUser(string email)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Email == email);
        }

        public bool IsAuthenticated(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
