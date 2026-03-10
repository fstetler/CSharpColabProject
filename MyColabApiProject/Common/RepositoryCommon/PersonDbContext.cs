using Microsoft.EntityFrameworkCore;
using MyColabApiProject;

namespace Common.RepositoryCommon
{
    public class PersonDbContext : DbContext
    {

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

    }
}
