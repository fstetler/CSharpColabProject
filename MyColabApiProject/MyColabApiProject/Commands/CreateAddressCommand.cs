using Common.CommonCommands;
using MyColabApiProject.Domains;

namespace MyColabApiProject.Commands
{
    public class CreateAddressCommand : CommandBase<AddressDto>
    {
        public required string StreetName { get; set; }
        public required string StreetNumber { get; set; }

        public required string PostalCode { get; set; }
        public required string City { get; set; }
    }
}
