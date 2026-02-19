using MediatR;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : IRequest<Person>
    {
        public string Name { get; set; }

        public CreatePersonCommand(string name)
        {
            Name = name;
        }
    }
}
