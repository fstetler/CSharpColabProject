using Common.CommonCommands;
using Common.Result;
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

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return Result<PersonDto>.Failure("Name cannot be empty or whitespace.");
            }

            Person person = new Person
            { 
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _repository.AddAsync(person);
            await _repository.SaveChangesAsync();
            return Result<PersonDto>.Success(PersonMapper.Map(person));
        }
    }
}
