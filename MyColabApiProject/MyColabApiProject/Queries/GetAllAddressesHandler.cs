using Common.CommonQueries;
using Common.Result;
using MyColabApiProject.Domains;
using MyColabApiProject.Repository;
using MyColabApiProject.Mappers;

namespace MyColabApiProject.Queries
{
    public class GetAllAddressesHandler : QueryHandlerBase<GetAllAddressesQuery, List<AddressDto>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAllAddressesHandler(IAddressRepository addressRepository) 
        {
            _addressRepository = addressRepository;
        }

        public override async Task<Result<List<AddressDto>>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            List<Address> addresses = await _addressRepository.GetAllAsync();
            return Ok(AddressMapper.Map(addresses));
        }
    }
}
