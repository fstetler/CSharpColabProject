using MyColabApiProject;
using Microsoft.EntityFrameworkCore;

namespace Common.RepositoryCommon
{
    public class RepositoryBase : IPersonRepository
    {

        private readonly PersonDbContext _db;

        public RepositoryBase(PersonDbContext personDbContext)
        {
            _db = personDbContext;
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await _db.Persons.ToListAsync();
        }
    }
}
