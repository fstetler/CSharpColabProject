using Common.CommonCommands;
using Common.Result;
using FluentValidation.Results;
using MyColabApiProject.Domains;
using MyColabApiProject.Mappers;
using MyColabApiProject.Repository;
using MyColabApiProject.Validator;

namespace MyColabApiProject.Commands
{
    public class CreateAddressHandler : CommandHandlerBase<CreateAddressCommand, AddressDto>
    {
        private readonly IAddressRepository _repository;

        public CreateAddressHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public override async Task<Result<AddressDto>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            CreateAddressCommandValidator validator = new CreateAddressCommandValidator();
            ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            Address address = new Address
            { 
                Id = Guid.NewGuid(),
                StreetName = request.StreetName,
                StreetNumber = request.StreetNumber,
                PostalCode = request.PostalCode,
                City = request.City,
            };

            await _repository.AddAsync(address);
            await _repository.SaveChangesAsync();
            return Ok(AddressMapper.Map(address));
        }
    }
}
