using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Repository
{
    public class PersonDbContext : DbContext
    {

        public PersonDbContext(DbContextOptions<PersonDbContext> dbContextOption) : base(dbContextOption)
        {

        }

        public DbSet<Person> People { get; set; } // remove when ability to add person is added
    }
}
