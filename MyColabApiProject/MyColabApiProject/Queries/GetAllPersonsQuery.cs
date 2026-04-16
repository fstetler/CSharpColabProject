using Common.CommonQueries;
using MyColabApiProject.Domains;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsQuery : QueryBase<PersonDto>
    {
        public Guid Id { get; set; }
        public String? Name { get; }
    }
}
