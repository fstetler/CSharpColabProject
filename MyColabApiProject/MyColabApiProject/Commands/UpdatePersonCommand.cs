using Common.CommonUpdateCommand;

namespace MyColabApiProject.Commands
{
    public class UpdatePersonCommand : UpdateCommandBase<Person>
    {
        public UpdatePersonCommand(Guid id, Person entity) : base(id, entity)
        {
        }
    }
}
