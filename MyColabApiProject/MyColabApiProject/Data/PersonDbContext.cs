using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject
{
    public class PersonDbContext : DbContext
    {

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons
        {
            get 
            { 
                return Set<Person>(); 
            }
        }
    }
}
