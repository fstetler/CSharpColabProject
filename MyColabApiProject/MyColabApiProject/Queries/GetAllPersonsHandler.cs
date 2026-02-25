using MediatR;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, List<Person>>
    {

        private readonly PersonRepository _personRepository;

        public GetAllPersonsHandler(PersonRepository personDbContext)
        {
            _personRepository = personDbContext;
        }

        public Task<List<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_personRepository.GetAllPersons());
        }
    }
}
