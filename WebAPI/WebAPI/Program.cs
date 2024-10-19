using WebAPI.Middlewares;
using Infrastructure;
using Application;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            // Add services to the container.

            builder.Services.AddInfrastructure(configuration);

            builder.Services.AddApplication(configuration);

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseMiddleware<AuthMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
