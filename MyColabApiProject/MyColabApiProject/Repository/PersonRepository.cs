using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Repository
{
    public class PersonRepository : IPersonRepository
    {

        private readonly PersonDbContext _db;

        public PersonRepository(PersonDbContext personDbContext)
        {
            _db = personDbContext;
        }

        public async Task<List<Person>> GetAllPersons() 
        { 
            return await _db.Persons.ToListAsync();    
        }
    }
}
