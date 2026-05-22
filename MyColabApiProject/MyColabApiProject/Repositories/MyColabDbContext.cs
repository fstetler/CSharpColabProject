using Microsoft.EntityFrameworkCore;
using MyColabApiProject.Data;

namespace MyColabApiProject.Repository
{
    public class MyColabDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public MyColabDbContext(DbContextOptions<MyColabDbContext> dbContextOption) : base(dbContextOption)
        {

        }

    }
}
