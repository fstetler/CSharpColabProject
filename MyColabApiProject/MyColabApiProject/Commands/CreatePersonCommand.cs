using Common.CommonCommands;
using MyColabApiProject.Data;
using MyColabApiProject.Domains;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : CommandBase<PersonDto>
    {
        public required string Name { get; set; }
        public required Address Address { get; set; }
    }
}
