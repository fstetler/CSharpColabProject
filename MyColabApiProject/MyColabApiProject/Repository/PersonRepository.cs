using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Repository
{
    public class PersonRepository : IPersonRepository
    {

        private readonly PersonDbContext _dbContext;

        public PersonRepository(PersonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Person> Persons()
        {
            return _dbContext.Persons;
        }
    }
}
