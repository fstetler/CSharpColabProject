using Common.CommonCommands;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : CommandBase<Person>
    {
        public required String Name { get; set; }
    }
}
