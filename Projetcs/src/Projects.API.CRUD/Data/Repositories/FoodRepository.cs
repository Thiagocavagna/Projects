using Microsoft.EntityFrameworkCore;
using Projects.API.CRUD.Domain.Entities;
using Projects.API.CRUD.Domain.IRepositories;
using Projects.Base.Data;

namespace Projects.API.CRUD.Data.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public FoodRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Food entity)
        {
            _context.Add(entity);
        }

        public async Task<List<Food>> GetAllAsync()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<Food> GetByIdAsync(Guid id)
        {
            return await _context.Foods.FindAsync(id);
        }

        public void Update(Food entity)
        {
            _context.Update(entity);
        }

        public void Remove(Food entity)
        {
            _context.Remove(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
