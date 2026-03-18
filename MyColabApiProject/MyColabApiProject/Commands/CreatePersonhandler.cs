using Common.CommonCommands;
using Common.CommonRepository;
using MediatR;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Commands
{
    public class CreatePersonhandler : CreateBaseHandler<CreateBaseCommand<Person>, Person>, IRequestHandler<CreatePersonCommand, Person>
    {

        private readonly IPersonRepository _personRepository;

        public CreatePersonhandler(IRepository<Person> repository) : base(repository)
        {
            _personRepository = repository as IPersonRepository;
        }

        public async Task<Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                Name = request.Entity.Name
            };

            await _personRepository.AddAsync(person);
            await _personRepository.SaveChangesAsync();
            return person;
        }

        protected override Person CreateEntity(CreateBaseCommand<Person> request)
        {
            return new Person { Id = Guid.NewGuid(), Name = request.Entity.Name };
        }
    }
}
