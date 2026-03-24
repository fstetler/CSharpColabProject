using Common.CommonCommands;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : CommandBase<Person>
    {
        public Person Person { get; set; }
        public CreatePersonCommand(Person person)
        {
            Person = person;
        }
    }
}
