using Common.CommonCommands;
using MyColabApiProject.Domains;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : CommandBase<PersonDto>
    {
        public required String Name { get; set; }
    }
}
