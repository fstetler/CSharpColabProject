using MyColabApiProject.Domains;
using System.Text.Json.Serialization;
using Common.CommonCommands;

namespace MyColabApiProject.Commands
{
    public class UpdateAddressCommand : CommandBase<AddressDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public required string StreetName { get; set; }
        public required string StreetNumber { get; set; }

        public required string PostalCode { get; set; }
        public required string City { get; set; }
    }
}
