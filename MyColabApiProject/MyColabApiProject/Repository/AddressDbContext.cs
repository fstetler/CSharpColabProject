using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Repository
{
    public class AddressDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public AddressDbContext(DbContextOptions<AddressDbContext> dbContextOption) : base(dbContextOption)
        {

        }

    }
}
