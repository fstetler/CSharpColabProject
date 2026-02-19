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

        [HttpPost]
        public async Task<ActionResult<Person>> Create([FromBody] string name)
        {
            var created = await _mediator.Send(new CreatePersonCommand(name));
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(Guid id)
        {
            var person = await _mediator.Send(new GetPersonByIdQuery(id));
            if (person is null)
            {
                return NotFound();
            }
            return person;
        }


    }
}
