using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Repository
{
    public interface IPersonRepository
    {
        public DbSet<Person> Persons { get; set; }
    }
}
