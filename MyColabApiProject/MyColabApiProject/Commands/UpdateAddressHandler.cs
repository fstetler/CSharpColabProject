using Common.CommonCommands;
using Common.Result;
using MyColabApiProject.Domains;
using MyColabApiProject.Mappers;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Commands
{
    public class UpdateAddressHandler : CommandHandlerBase<UpdateAddressCommand, AddressDto>
    {

        private readonly IAddressRepository _repository;

        public UpdateAddressHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public override async Task<Result<AddressDto>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            Address? address = await _repository.GetByIdAsync(request.Id);

            if (address is null)
            {
                return NotFound($"Address with id '{request.Id}' was not found");
            }

            address.StreetName = request.StreetName;
            address.StreetNumber = request.StreetNumber;
            address.PostalCode = request.PostalCode;
            address.City = request.City;

            _repository.Update(address);
            await _repository.SaveChangesAsync();
            return Ok(AddressMapper.Map(address));
        }
    }
}
