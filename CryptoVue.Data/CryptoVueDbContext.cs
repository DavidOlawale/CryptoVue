using CryptoVue.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace CryptoVue.Data
{
    public class CryptoVueDbContext : DbContext
    {
        public CryptoVueDbContext(DbContextOptions<CryptoVueDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CryptoToken> CryptoTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                MakeUser("user@app.com", "password@123", Roles.Admin),
                MakeUser("user@app.com", "password@123", Roles.Admin)
                );
        }

        private User MakeUser(string email, string password, string role = "Admin")
        {
            return new User
            {
                Email = email,
                Role = role,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };
        }
    }
}
