using Projects.API.CRUD.Data.Repositories;
using Projects.API.CRUD.Domain.IRepositories;
using Projects.API.CRUD.Services;

namespace Projects.API.CRUD.Configuration
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
