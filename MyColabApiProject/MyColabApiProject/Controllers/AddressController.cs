using Common.Controllers;
using Common.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyColabApiProject.Commands;
using MyColabApiProject.Domains;
using MyColabApiProject.Queries;
using System.Net;

namespace MyColabApiProject.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController : MyColabApiProjectControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(AddressDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            Result<List<AddressDto>> addressDtos = await _mediator.Send(new GetAllAddressesQuery());
            return GetActionResult(addressDtos);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddressDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand createAddressCommand)
        {
            Result<AddressDto> AddressDto = await _mediator.Send(createAddressCommand);
            return GetActionResult(AddressDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AddressDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateAddress(Guid id, [FromBody] UpdateAddressCommand updateAddressCommand)
        {
            updateAddressCommand.Id = id;
            Result<AddressDto> AddressDto = await _mediator.Send(updateAddressCommand);   
            return GetActionResult(AddressDto);
        }
    }
}
