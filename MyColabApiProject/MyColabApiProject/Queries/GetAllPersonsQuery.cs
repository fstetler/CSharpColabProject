using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsQuery : IRequest<List<Person>>
    {


    }
}
