using Common.CommonCommands;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : CreateBaseCommand<Person>
    {
        public CreatePersonCommand(Person entity) : base(entity)
        {
        }
    }
}
