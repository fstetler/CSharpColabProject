using Common.CommonCommands;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : CreateBaseCommand<Person>
    {
        public CreatePersonCommand(string name) : base(name)
        {
            Name = name;
        }
    }
}
