using Common.CommonCommands;
using MyColabApiProject.Domains;

namespace MyColabApiProject.Commands
{
    public class UpdatePersonCommand : CommandBase<PersonDto>
    {
        public Guid Id { get; set; }
        public required String Name { get; set; }
    }
}
