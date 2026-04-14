using Common.CommonUpdateCommand;

namespace MyColabApiProject.Commands
{
    public class UpdatePersonCommand : UpdateCommandBase<Person>
    {
        public Guid Id { get; set; }
        public required String Name { get; set; }
    }
}
