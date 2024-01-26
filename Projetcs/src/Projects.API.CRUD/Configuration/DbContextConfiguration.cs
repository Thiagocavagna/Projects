using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projects.API.CRUD.Data;
using Projects.Base.Extensions;

namespace Projects.API.CRUD.Configuration
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetDBConnectionString();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
