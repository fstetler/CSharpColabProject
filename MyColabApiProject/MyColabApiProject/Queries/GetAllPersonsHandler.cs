using MediatR;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, List<Person>>
    {

        public readonly PersonRepository personRepository;

        public GetAllPersonsHandler(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<List<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return personRepository.Persons();        
        }
    }
}
