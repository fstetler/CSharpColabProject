using Common.CommonCommands;
using Common.CommonRepository;

namespace MyColabApiProject.Commands
{
    public class CreatePersonhandler : CreateBaseHandler<CreatePersonCommand, Person>
    {

        public CreatePersonhandler(IRepository<Person> repository) : base(repository)
        {
        }

        protected override Person CreateEntity(CreatePersonCommand request)
        {
            return new Person 
            { 
                Id = Guid.NewGuid(), 
                Name = request.Entity.Name 
            };
        }
    }
}
