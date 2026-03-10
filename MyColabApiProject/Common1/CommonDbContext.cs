using Microsoft.EntityFrameworkCore;

namespace Common
{
    public class CommonDbContext<TEntity> : DbContext where TEntity : class
    {

        public CommonDbContext(DbContextOptions<CommonDbContext<TEntity>> options) : base(options)
        {
        }

        public DbSet<TEntity> GetAll { get; set; }

    }
}
