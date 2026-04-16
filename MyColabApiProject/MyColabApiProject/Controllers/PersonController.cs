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
        public async Task<ActionResult<PersonDto>> CreatePerson([FromBody] CreatePersonCommand createPersonCommand)
        {
            PersonDto personDto = await _mediator.Send(createPersonCommand);
            return CreatedAtAction(nameof(Get), personDto.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDto>> UpdatePerson(Guid id, [FromBody] UpdatePersonCommand updatePersonCommand)
        {
            updatePersonCommand.Id = id;
            PersonDto? personDto = await _mediator.Send(updatePersonCommand);   
            
            if (personDto is null)
            {
                return NotFound();
            }
            
            return Ok(personDto);
        }
    }
}
