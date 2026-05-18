using Common.CommonCommands;
using Common.Result;
using FluentValidation.Results;
using MyColabApiProject.Domains;
using MyColabApiProject.Mappers;
using MyColabApiProject.Repository;
using MyColabApiProject.Validator;

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

            UpdatePersonCommandValidator validator = new UpdatePersonCommandValidator();
            ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            Person? person = await _repository.GetByIdAsync(request.Id);

            if (person is null)
            {
                return NotFound($"Person with id '{request.Id}' was not found");
            }

            person.Name = request.Name;
            person.Address = request.Address;
            _repository.Update(person);
            await _repository.SaveChangesAsync();
            return Ok(PersonMapper.Map(person));
        }
    }
}
