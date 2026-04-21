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

        public override async Task<ResultGeneric<PersonDto>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return ResultGeneric<PersonDto>.Failure("Name cannot be empty or whitespace.");
            }

            Person? person = await _repository.GetByIdAsync(request.Id);

            if (person is null)
            {
                return ResultGeneric<PersonDto>.Failure($"Person with id '{request.Id}' was not found");
            }

            person.Name = request.Name;
            _repository.Update(person);
            await _repository.SaveChangesAsync();
            return ResultGeneric<PersonDto>.Success(PersonMapper.Map(person));
        }
    }
}
