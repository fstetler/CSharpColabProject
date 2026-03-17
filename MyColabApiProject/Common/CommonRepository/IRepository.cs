namespace Common.CommonRepository
{
    public interface IRepository<TEntity>
    {
        public Task<List<TEntity>> GetAllAsync();

        public Task<TEntity> AddAsync(TEntity entity);
    }
}
