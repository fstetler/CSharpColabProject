using Common.CommonQueries;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsHandler : GetAllBaseHandler<Person>
    {

        public GetAllPersonsHandler(IPersonRepository personRepository) : base(personRepository) 
        { 
        }
    }
}
