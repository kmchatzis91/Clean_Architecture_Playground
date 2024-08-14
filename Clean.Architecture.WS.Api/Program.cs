using Clean.Architecture.WS.Api.Utils;
using Clean.Architecture.WS.Infrastructure.Extensions;
using Clean.Architecture.WS.Infrastructure.Mappings;
using Dapper.FluentMap;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Clean.Architecture.WS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Added Services
            // Context & Repositories
            builder.Services.RegisterServices();

            // Services
            builder.Services.AddScoped<RequestValidationService>();

            // Mappings
            FluentMapper.Initialize(options =>
            {
                // entities
                options.AddMap(new EmployeeMap());
                options.AddMap(new CompanyMap());
                options.AddMap(new RoleMap());

                // views
                options.AddMap(new EmployeeViewMap());
            });
            #endregion

            // Add services to the container.
            builder.Services.AddControllers();

            // Add for Jwt Auth
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            // Add for Jwt Auth
            builder.Services.AddAuthorization();

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

            // Add for Jwt Auth
            app.UseAuthentication();

            // Add for Jwt Auth
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
