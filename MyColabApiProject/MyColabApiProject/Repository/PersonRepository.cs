
using Common;
using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Repository
{
    public class PersonRepository : RepositoryBase<Person>
    {
        private readonly CommonDbContext<Person> _db;

        public PersonRepository(CommonDbContext<Person> personDbContext) : base(personDbContext)
        {
            _db = personDbContext;
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await _db.GetAll.ToListAsync();
        }
    }
}
