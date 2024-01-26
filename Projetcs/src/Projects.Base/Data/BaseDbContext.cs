using Microsoft.EntityFrameworkCore;
using Upside.Base.Domain;

namespace Projects.Base.Data
{
    public class BaseDbContext : DbContext, IUnitOfWork 
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public virtual async Task<bool> CommitAsync()
        {
            foreach (var entry in ChangeTracker.Entries<IEntity>())
            {
                //TODO: implementar ações
            }

            var success = await base.SaveChangesAsync() > 0;

            return success;
        }
    }
}
