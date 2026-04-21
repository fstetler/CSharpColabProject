using Common.CommonCommands;
using MyColabApiProject.Domains;
using System.Text.Json.Serialization;
using Common.Result;

namespace MyColabApiProject.Commands
{
    public class UpdatePersonCommand : CommandBase<ResultGeneric<PersonDto>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public required String Name { get; set; }
    }
}
