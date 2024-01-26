using Upside.Base.Domain;

namespace Projects.Base.Data
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
