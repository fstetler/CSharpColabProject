using Common.CommonCommands;
using MyColabApiProject.Domains;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : CommandBase<PersonDto>
    {
        public Guid Id { get; set; }
        public required String Name { get; set; }
    }
}
