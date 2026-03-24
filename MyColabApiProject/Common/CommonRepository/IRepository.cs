namespace Common.CommonRepository
{
    public interface IRepository<TEntity>
    {
        public Task<List<TEntity>> GetAllAsync();

        public void AddAsync(TEntity entity);

        public Task<int> SaveChangesAsync();
    }
}
