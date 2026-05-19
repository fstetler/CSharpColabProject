using Common.CommonCommands;
using Common.Result;
using MyColabApiProject.Domains;
using MyColabApiProject.Mappers;
using MyColabApiProject.Repository;

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
