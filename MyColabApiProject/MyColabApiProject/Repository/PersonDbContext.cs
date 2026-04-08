using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Repository
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonDbContext(DbContextOptions<PersonDbContext> dbContextOption) : base(dbContextOption)
        {

        }

    }
}
