using Common.CommonRepository;

namespace MyColabApiProject.Repository
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(MyColabDbContext myColabDbContext) : base(myColabDbContext)
        {
        }
    }
}
