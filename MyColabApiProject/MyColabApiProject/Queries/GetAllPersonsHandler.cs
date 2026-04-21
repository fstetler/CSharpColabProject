using Common.CommonQueries;
using Common.Result;
using MyColabApiProject.Domains;
using MyColabApiProject.Repository;
using MyColabApiProject.Mappers;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsHandler : QueryHandlerBase<GetAllPersonsQuery, List<PersonDto>>
    {
        private readonly IPersonRepository _personRepository;

        public GetAllPersonsHandler(IPersonRepository personRepository) 
        { 
            _personRepository = personRepository;
        }

        public override async Task<ResultGeneric<List<PersonDto>>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            List<Person> persons = await _personRepository.GetAllAsync();
            return ResultGeneric<List<PersonDto>>.Success(PersonMapper.Map(persons));
        }
    }
}
