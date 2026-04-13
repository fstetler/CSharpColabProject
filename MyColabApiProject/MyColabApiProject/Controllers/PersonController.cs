using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyColabApiProject.Commands;
using MyColabApiProject.Domains;
using MyColabApiProject.Queries;

namespace MyColabApiProject.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDto>>> Get()
        {
            List<PersonDto> personsDtos = await _mediator.Send(new GetAllPersonsQuery());
            return personsDtos;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreatePerson([FromBody] CreatePersonCommand createPersonCommand)
        {
            Person person = await _mediator.Send(createPersonCommand);
            return CreatedAtAction(nameof(Get), person.Id.ToString());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDto>> UpdatePerson(Guid id, [FromBody] UpdatePersonCommand updatePersonCommand)
        {
            updatePersonCommand.Id = id;
            Person person = await _mediator.Send(updatePersonCommand);
            PersonDto personDto = new PersonDto { Name = person.Name };
            return Ok(personDto);
        }

    }
}
