using Common.CommonCommands;
using Common.Result;
using MyColabApiProject.Domains;

namespace MyColabApiProject.Commands
{
    public class CreatePersonCommand : CommandBase<ResultGeneric<PersonDto>>
    {
        public required String Name { get; set; }
    }
}
