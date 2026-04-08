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
            List<Person> persons = await _mediator.Send(new GetAllPersonsQuery());
            List<PersonDto> personDtos = persons.Select(p => new PersonDto { Name = p.Name }).ToList();
            return personDtos;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreatePerson([FromBody] CreatePersonCommand createPersonCommand)
        {
            Person person = await _mediator.Send(createPersonCommand);
            return CreatedAtAction(nameof(Get), person.Id.ToString());
        }
    }
}
