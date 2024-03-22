using CryptoVue.Authentication;
using CryptoVue.Services;
using CryptoVue.Services.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CryptoVue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var jwtOptionsSection = builder.Configuration.GetRequiredSection("Jwt");
            builder.Services.Configure<JwtOptions>(jwtOptionsSection);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                var configKey = jwtOptionsSection["Key"];
                var key = Encoding.UTF8.GetBytes(configKey);

                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtOptionsSection["Issuer"],
                    ValidAudience = jwtOptionsSection["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            builder.Services.AddDbContext<CryptoVue.Data.CryptoVueDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("CryptoVueConnection"));
            });

            builder.Services.AddAuthorization();

            builder.Services.AddTransient<IJwtService, JwtService>();
            builder.Services.AddTransient<IUserService, UserService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
