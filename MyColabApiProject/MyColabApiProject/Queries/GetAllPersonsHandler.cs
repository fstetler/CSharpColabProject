using MediatR;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, List<Person>>
    {

        private readonly IPersonRepository _personRepository;

        public GetAllPersonsHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<List<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_personRepository.GetAllPersonsAsync().Result);
        }
    }
}
