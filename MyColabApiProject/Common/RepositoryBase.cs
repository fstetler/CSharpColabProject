using Microsoft.EntityFrameworkCore;

namespace Common
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly CommonDbContext<TEntity> _dB;

        public RepositoryBase(CommonDbContext<TEntity> dbContext)
        {
            _dB = dbContext;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _dB.GetAll.ToListAsync();
        }
    }
}
