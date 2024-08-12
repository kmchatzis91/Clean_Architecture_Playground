using Clean.Architecture.WS.Infrastructure.Extensions;
using Clean.Architecture.WS.Infrastructure.Mappings;
using Dapper.FluentMap;

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

            // Mappings
            FluentMapper.Initialize(config =>
            {
                // entities
                config.AddMap(new EmployeeMap());
                config.AddMap(new CompanyMap());
                config.AddMap(new RoleMap());

                // views
                config.AddMap(new EmployeeViewMap());
            });
            #endregion

            // Add services to the container.

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
