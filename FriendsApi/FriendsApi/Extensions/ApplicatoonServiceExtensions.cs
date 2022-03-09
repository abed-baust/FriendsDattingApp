using FriendsApi.Data;
using FriendsApi.Interface;
using FriendsApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FriendsApi.Extensions
{
    public static class ApplicatoonServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(config.GetConnectionString("FriendsDb")));
            return services;
        }

    }
}
