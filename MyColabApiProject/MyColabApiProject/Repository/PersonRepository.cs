namespace MyColabApiProject.Repository
{
    public class PersonRepository : IPersonRepository
    {

        private readonly PersonDbContext _db;

        public PersonRepository(PersonDbContext personDbContext)
        {
            _db = personDbContext;
        }

        public List<Person> GetAllPersons() 
        { 
            return _db.Persons.ToList();    
        }
    }
}
