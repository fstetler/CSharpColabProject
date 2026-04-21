using Common.Result;
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
            Result<List<PersonDto>> personsDtos = await _mediator.Send(new GetAllPersonsQuery());

            if (personsDtos.IsFailure)
            {
                return NotFound(personsDtos.Error);
            }

            return Ok(personsDtos.Value);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> CreatePerson([FromBody] CreatePersonCommand createPersonCommand)
        {
            Result<PersonDto> personDto = await _mediator.Send(createPersonCommand);

            if (personDto.IsFailure) 
            {
                return BadRequest(personDto.Error);
            }
            return CreatedAtAction(nameof(Get), personDto.Value.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDto>> UpdatePerson(Guid id, [FromBody] UpdatePersonCommand updatePersonCommand)
        {
            updatePersonCommand.Id = id;
            Result<PersonDto> personDto = await _mediator.Send(updatePersonCommand);   

            if (personDto.IsFailure)
            {
                return NotFound(personDto.Error);
            }

            return Ok(personDto.Value);
        }
    }
}
