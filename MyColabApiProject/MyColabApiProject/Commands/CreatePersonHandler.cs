using MediatR;

namespace MyColabApiProject.Commands
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, Person>, ICreatePersonHandler
    {
        private readonly PersonDbContext _db;

        public CreatePersonHandler(PersonDbContext db) 
        { 
            _db = db; 
        }    


        public async Task<Person> Handle(CreatePersonCommand request, CancellationToken ct)
        {
            var person = new Person { Name = request.Name };
            _db.Persons.Add(person);
            await _db.SaveChangesAsync(ct);
            return person;
        }
    }
}
