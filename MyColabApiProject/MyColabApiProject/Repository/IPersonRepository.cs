namespace MyColabApiProject.Repository
{
    public interface IPersonRepository
    {
        public Task<List<Person>> GetAllPersons();
    }
}
