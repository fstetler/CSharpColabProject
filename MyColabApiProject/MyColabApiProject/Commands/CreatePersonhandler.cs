using Common.CommonCommands;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Commands
{
    public class CreatePersonhandler : CommandHandlerBase<CreatePersonCommand, Person>
    {
        private readonly IPersonRepository _repository;

        public CreatePersonhandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public override async Task<Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = new Person
            { 
                Id = Guid.NewGuid(),
                Name = request.Person.Name
            };

            _repository.AddAsync(person);
            await _repository.SaveChangesAsync();
            return person;
        }
    }
}
