using WebAPI.Middlewares;
using Infrastructure;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Application.Security;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddMemoryCache();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = builder.Services.BuildServiceProvider().GetService<IJwtHandler>().Parameters;
            });

            builder.Services.AddInfrastructure(configuration);

            builder.Services.AddApplication(configuration);

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseCors(options =>
            {
                options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.UseMiddleware<AuthMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
