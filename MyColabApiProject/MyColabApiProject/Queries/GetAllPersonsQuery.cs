using MediatR;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsQuery : IRequest<List<Person>>
    {

    }
}
