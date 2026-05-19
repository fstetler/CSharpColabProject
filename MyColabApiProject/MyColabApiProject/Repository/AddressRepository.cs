using Common.CommonRepository;

namespace MyColabApiProject.Repository
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(AddressDbContext addressDbContext) : base(addressDbContext)
        {
        }
    }
}
