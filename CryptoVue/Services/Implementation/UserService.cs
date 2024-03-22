using CryptoVue.Data.Models;

namespace CryptoVue.Services.Implementation
{
    public class UserService: IUserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>
            {
                new User{ Email = "olawaledavid11@gmail.com", Role = "Admin", PasswordHash = BCrypt.Net.BCrypt.HashPassword("password@123") },
                new User{ Email = "davolawale1@gmail.com", Role = "Admin", PasswordHash = BCrypt.Net.BCrypt.HashPassword("password1@321"), },
            };
        }

        public User? GetUser(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }

        public bool IsAuthenticated(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
