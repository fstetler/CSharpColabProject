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
            Task<List<Person>> persons = _mediator.Send(new GetAllPersonsQuery());   
            return await persons;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreatePerson([FromBody] CreatePersonCommand createPersonCommand)
        {
            Task<Person> person = _mediator.Send(createPersonCommand);
            return CreatedAtAction(nameof(Get), person.Result.Id);
        }
    }
}
