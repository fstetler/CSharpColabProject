using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyColabApiProject.Commands;
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
        public async Task<ActionResult<List<Person>>> Get()
        {
            var persons = await _mediator.Send(new GetAllPersonsQuery());   
            return persons;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson([FromBody] Person personEntity)
        {
            var person = await _mediator.Send(new CreatePersonCommand(personEntity));
            return CreatedAtAction(nameof(Get), person);
        }
    }
}
