using Projects.Base.Models.Result;
using Projects.Base.Services;
using Projects.Foods.API.Domain.Entities;
using Projects.Foods.API.Domain.IRepositories;
using Projects.Foods.API.Models.Foods;

namespace Projects.Foods.API.Services
{
    public class FoodService : BaseService, IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<Result> CreateAsync(FoodRequest request)
        {
            Food food = new(request.Name, request.Description, request.Type, request.Protein, request.Carbohydrate, request.Fat);

            _foodRepository.Add(food);

            if (!await _foodRepository.UnitOfWork.CommitAsync())
                return Failed("Ocorreu um erro ao salvar o alimento");

            return Ok();
        }

        public async Task<(Result result, List<FoodView> foodViews)> GetAllAsync()
        {
            var food = await  _foodRepository.GetAllAsync();

            if(food == null)
                return Failed<List<FoodView>>("Nenhum alimento encontrado");

           return Ok(food.Select(x => (FoodView)x).ToList());
        }

        public async Task<(Result result, FoodView foodView)> GetByIdAsync(Guid id)
        {
            var food = await _foodRepository.GetByIdAsync(id);

            if (food == null)
                return Failed<FoodView>("Nenhum alimento encontrado");

            return Ok(food);
        }

        public async Task<Result> RemoveAsync(Guid id)
        {
            var food = await _foodRepository.GetByIdAsync(id);

            if (food == null)
                return Failed("Nenhum alimento encontrado");

            _foodRepository.Remove(food);

            if (!await _foodRepository.UnitOfWork.CommitAsync())
                return Failed("Ocorreu um erro ao remover o alimento");

            return Ok();
        }

        public async Task<Result> UpdateAsync(Guid id, FoodRequest request)
        {
            var food = await _foodRepository.GetByIdAsync(id);

            if(food == null)
                return Failed("Nenhum alimento encontrado");

            food.Update(request.Name, request.Description, request.Type, request.Protein, request.Carbohydrate, request.Fat);

            _foodRepository.Update(food);

            if (!await _foodRepository.UnitOfWork.CommitAsync())
                return Failed("Ocorreu um erro ao atualizar o alimento");

            return Ok();
        }
    }
}
