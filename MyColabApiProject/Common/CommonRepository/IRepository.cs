namespace Common.CommonRepository
{
    public interface IRepository<TEntity>
    {
        public Task<List<TEntity>> GetAllAsync();

        public Task AddAsync(TEntity entity);

        public Task<int> SaveChangesAsync();
    }
}
