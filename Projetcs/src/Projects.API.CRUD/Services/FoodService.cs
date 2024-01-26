using Projects.API.CRUD.Domain.Entities;
using Projects.API.CRUD.Domain.IRepositories;
using Projects.API.CRUD.Models.Foods;

namespace Projects.API.CRUD.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task CreateAsync(FoodRequest request)
        {
            Food food = new(request.Name, request.Description, request.Type, request.Protein, request.Carbohydrate, request.Fat);

            _foodRepository.Add(food);

            if (!await _foodRepository.UnitOfWork.CommitAsync())
                throw new Exception("Ocorreu um erro ao salvar o alimento");            
        }

        public async Task<List<FoodView>> GetAllAsync()
        {
            var food = await  _foodRepository.GetAllAsync();

            if(food == null)
                throw new Exception("Nenhum alimento encontrado");

           return food.Select(x => (FoodView)x).ToList();
        }

        public Task<FoodView> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IFoodService
    {
        //TODO: precisa implementar forma de busca com query, para busca por nome e afins
        Task<FoodView> GetByIdAsync(Guid id);
        Task<List<FoodView>> GetAllAsync();
        Task CreateAsync(FoodRequest request);    
    }
}
