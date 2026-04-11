using Common.CommonQueries;
using MyColabApiProject.Domains;
using MyColabApiProject.Repository;
using MyColabApiProject.Mappers;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsHandler : QueryHandlerBase<GetAllPersonsQuery, PersonDto>
    {
        private readonly IPersonRepository _personRepository;

        public GetAllPersonsHandler(IPersonRepository personRepository) 
        { 
            _personRepository = personRepository;
        }

        public override async Task<List<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            List<Person> persons = await _personRepository.GetAllAsync();
            return PersonMapper.Map(persons);
        }
    }
}
