using Common.CommonCommands;
using Common.Result;
using MyColabApiProject.Domains;
using MyColabApiProject.Mappers;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Commands
{
    public class UpdatePersonHandler : CommandHandlerBase<UpdatePersonCommand, PersonDto>
    {

        private readonly IPersonRepository _repository;

        public UpdatePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public override async Task<Result<PersonDto>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return Result<PersonDto>.Failure("Name cannot be empty or whitespace.");
            }

            Person? person = await _repository.GetByIdAsync(request.Id);

            if (person is null)
            {
                return Result<PersonDto>.Failure($"Person with id '{request.Id}' was not found");
            }

            person.Name = request.Name;
            _repository.Update(person);
            await _repository.SaveChangesAsync();
            return Result<PersonDto>.Success(PersonMapper.Map(person));
        }
    }
}
