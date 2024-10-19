using Application.Repository;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register services
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFlashCardRepository, FlashCardRepository>();

            return services;
        }
    }
}
