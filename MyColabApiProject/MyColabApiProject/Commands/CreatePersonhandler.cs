using Common.CommonCommands;
using Common.Result;
using MyColabApiProject.Data;
using MyColabApiProject.Domains;
using MyColabApiProject.Mappers;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Commands
{
    public class CreatePersonHandler : CommandHandlerBase<CreatePersonCommand, PersonDto>
    {
        private readonly IPersonRepository _repository;

        public CreatePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public override async Task<Result<PersonDto>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = new Person
            { 
                Id = Guid.NewGuid(),
                Name = request.Name,
                Address = request.Address
            };

            await _repository.AddAsync(person);
            await _repository.SaveChangesAsync();
            return Ok(PersonMapper.Map(person));
        }
    }
}
