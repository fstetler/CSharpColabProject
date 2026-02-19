using MediatR;

namespace MyColabApiProject.Queries
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {

        private readonly PersonDbContext _db;
        public GetPersonByIdHandler(PersonDbContext db)
        {
            _db = db;
        }
        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.Persons.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}
