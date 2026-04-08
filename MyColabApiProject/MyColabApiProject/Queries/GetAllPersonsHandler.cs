using Common.CommonQueries;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsHandler : QueryHandlerBase<GetAllPersonsQuery, Person>
    {
        private readonly IPersonRepository _personRepository;

        public GetAllPersonsHandler(IPersonRepository personRepository) 
        { 
            _personRepository = personRepository;
        }

        public override async Task<List<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetAllAsync();
        }
    }
}
