using Microsoft.EntityFrameworkCore;
using MyColabApiProject.Common;

namespace MyColabApiProject.Repository
{
    public class PersonRepository : RepositoryBase
    {
        private readonly PersonDbContext _db;

        public PersonRepository(PersonDbContext personDbContext) : base(personDbContext)
        {
            _db = personDbContext;
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await _db.Persons.ToListAsync();
        }
    }
}
