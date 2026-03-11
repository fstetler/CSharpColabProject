using Microsoft.EntityFrameworkCore;

namespace Common
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly DbContext _db;

        public RepositoryBase(DbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }
    }
}
