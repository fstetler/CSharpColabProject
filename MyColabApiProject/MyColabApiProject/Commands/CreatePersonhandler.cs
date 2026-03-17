using Common.CommonCommands;
using Common.CommonRepository;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Commands
{
    public class CreatePersonhandler : CreateBaseHandler<Person>
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonhandler(IRepository<Person> repository) : base(repository)
        {
            _personRepository = (IPersonRepository)repository;
        }

        protected override Person CreateEntity(CreateBaseCommand<Person> request)
        {
            return new Person { Id = Guid.NewGuid(), Name = request.Name };
        }
    }
}
