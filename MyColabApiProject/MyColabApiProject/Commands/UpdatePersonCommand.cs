using MyColabApiProject.Domains;
using System.Text.Json.Serialization;
using Common.CommonCommands;
using MyColabApiProject.Data;

namespace MyColabApiProject.Commands
{
    public class UpdatePersonCommand : CommandBase<PersonDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Address Address { get; set; }
    }
}
