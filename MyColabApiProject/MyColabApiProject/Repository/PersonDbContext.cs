using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Repository
{
    public class PersonDbContext : DbContext
    {

        public PersonDbContext(DbContextOptions<PersonDbContext> dbContextOption) : base(dbContextOption)
        {

        }

        public DbSet<Person> Persons { get; set; } // remove when ability to add person is added
    }
}
