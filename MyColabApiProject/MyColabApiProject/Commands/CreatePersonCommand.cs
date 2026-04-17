using Common.CommonCommands;
using MyColabApiProject.Domains;
using System.Text.Json.Serialization;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : CommandBase<PersonDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public required String Name { get; set; }
    }
}
