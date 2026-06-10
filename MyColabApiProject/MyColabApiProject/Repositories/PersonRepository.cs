using Common.CommonRepository;
using Microsoft.EntityFrameworkCore;
using MyColabApiProject.Data;

namespace MyColabApiProject.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        private readonly MyColabDbContext _dbContext;

        public PersonRepository(MyColabDbContext myColabDbContext) : base(myColabDbContext)
        {
            _dbContext = myColabDbContext;
        }

        public override async Task<Person?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Persons.Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<List<Person>> GetAllAsync()
        {
            return await _dbContext.Persons.Include(p => p.Address).ToListAsync();
        }
}
}
