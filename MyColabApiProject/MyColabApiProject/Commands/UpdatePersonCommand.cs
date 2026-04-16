using Common.CommonCommands;
using MyColabApiProject.Domains;
using System.Text.Json.Serialization;

namespace MyColabApiProject.Commands
{
    public class UpdatePersonCommand : CommandBase<PersonDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public required String Name { get; set; }
    }
}
