using Projects.Foods.API.Data.Repositories;
using Projects.Foods.API.Domain.IRepositories;
using Projects.Foods.API.Services;

namespace Projects.Foods.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IFoodService, FoodService>();    
        }
    }
}
