using Common.CommonRepository;
using MyColabApiProject.Data;

namespace MyColabApiProject.Repository
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(MyColabDbContext myColabDbContext) : base(myColabDbContext)
        {
        }
    }
}
