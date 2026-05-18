using Common.CommonCommands;
using Common.Result;
using FluentValidation.Results;
using MyColabApiProject.Domains;
using MyColabApiProject.Mappers;
using MyColabApiProject.Repository;
using MyColabApiProject.Validator;

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

            CreatePersonCommandValidator validator = new CreatePersonCommandValidator();
            ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

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
