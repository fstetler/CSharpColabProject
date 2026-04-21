using MyColabApiProject.Domains;
using System.Text.Json.Serialization;
using Common.CommonCommands;

namespace MyColabApiProject.Commands
{
    public class UpdatePersonCommand : CommandBase<PersonDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public required String Name { get; set; }
    }
}
