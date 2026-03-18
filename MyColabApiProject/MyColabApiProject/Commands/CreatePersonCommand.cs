using Common.CommonCommands;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : CreateBaseCommand<Person>
    {
        public string Name { get; set; }

        public CreatePersonCommand(string name) : base(new Person { Name = name })
        {
            Name = name;
        }
    }
}
