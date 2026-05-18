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
    [Route("person")]
    public class PersonController : MyColabApiProjectControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PersonDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            Result<List<PersonDto>> personsDtos = await _mediator.Send(new GetAllPersonsQuery());
            return GetActionResult(personsDtos);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand createPersonCommand)
        {
            Result<PersonDto> personDto = await _mediator.Send(createPersonCommand);
            return GetActionResult(personDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PersonDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdatePerson(Guid id, [FromBody] UpdatePersonCommand updatePersonCommand)
        {
            updatePersonCommand.Id = id;
            Result<PersonDto> personDto = await _mediator.Send(updatePersonCommand);   
            return GetActionResult(personDto);
        }
    }
}
