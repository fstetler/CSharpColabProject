using Common.CommonCommands;
using MyColabApiProject.Domains;
using MyColabApiProject.Mappers;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Commands
{
    public class CreatePersonhandler : CommandHandlerBase<CreatePersonCommand, PersonDto>
    {
        private readonly IPersonRepository _repository;

        public CreatePersonhandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public override async Task<PersonDto?> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = new Person
            { 
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _repository.AddAsync(person);
            await _repository.SaveChangesAsync();
            return PersonMapper.Map(person);
        }
    }
}
