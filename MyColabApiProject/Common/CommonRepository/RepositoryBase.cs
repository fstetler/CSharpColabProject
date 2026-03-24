using Microsoft.EntityFrameworkCore;

namespace Common.CommonRepository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly DbContext _db;

        public RepositoryBase(DbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
