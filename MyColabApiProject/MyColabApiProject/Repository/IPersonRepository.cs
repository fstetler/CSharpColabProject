using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Repository
{
    public interface IPersonRepository
    {
        public List<Person> Persons();
    }
}
