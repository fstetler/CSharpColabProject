
using Common;
using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(PersonDbContext personDbContext) : base(personDbContext)
        {
        }
    }
}
