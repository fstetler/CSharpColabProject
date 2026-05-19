using Riok.Mapperly.Abstractions;
using MyColabApiProject.Domains;

namespace MyColabApiProject.Mappers
{
    [Mapper]
    public static partial class AddressMapper
    {
        public static partial AddressDto Map(Address address);
        public static partial List<AddressDto> Map(IEnumerable<Address> addresses);
    }
}
