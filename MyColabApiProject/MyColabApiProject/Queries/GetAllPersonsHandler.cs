using MediatR;
using Microsoft.EntityFrameworkCore;
using MyColabApiProject;

namespace MyColabApiProject.Queries
{
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, List<Person>>
    {

        private readonly PersonDbContext _db;

        public GetAllPersonsHandler(PersonDbContext db)
        {

            this._db = db;
        }

        public async Task<List<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _db.Persons.ToListAsync(cancellationToken);
        }

        //public async Task<DbSet<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        //{
        //    return await _db.Persons.ToListAsync(cancellationToken);
        //}

        //Task<List<Person>> IRequestHandler<GetAllPersonsQuery, List<Person>>.Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
