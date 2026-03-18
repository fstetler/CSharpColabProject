using Common.CommonQueries;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsHandler : GetAllBaseHandler<GetAllPersonsQuery, Person>
    {

        public GetAllPersonsHandler(IPersonRepository personRepository) : base(personRepository) 
        { 
        }
    }
}
