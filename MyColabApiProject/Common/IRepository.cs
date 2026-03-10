namespace Common
{
    public interface IRepository<TEntity>
    {
        public Task<List<TEntity>> GetAllAsync();
    }
}
