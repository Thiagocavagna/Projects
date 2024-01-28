using Projects.Base.Models.Result;
using Projects.Foods.API.Models.Foods;

namespace Projects.Foods.API.Services
{
    public interface IFoodService 
    {
        Task<(Result result, FoodView foodView)> GetByIdAsync(Guid id);
        Task<(Result result, List<FoodView> foodViews)> GetAllAsync();
        Task<Result> CreateAsync(FoodRequest request);
        Task<Result> UpdateAsync(Guid id, FoodRequest request);
        Task<Result> RemoveAsync(Guid id);
    }
}
