using Common.CommonCommands;
using MyColabApiProject.Domains;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : CommandBase<PersonDto>
    {
        public required string Name { get; set; }
    }
}
