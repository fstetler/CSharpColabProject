using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, List<Person>>
    {

        private readonly PersonDbContext _personDbContext;

        public GetAllPersonsHandler(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }

        public async Task<List<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _personDbContext.Persons.ToListAsync(cancellationToken);
        }
    }
}
