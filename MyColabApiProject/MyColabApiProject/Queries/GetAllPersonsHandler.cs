using Common;
using MediatR;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, List<Person>>
    {

        private readonly IRepository<Person> _personRepository;

        public GetAllPersonsHandler(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<List<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_personRepository.GetAllAsync().Result);
        }
    }
}
