using MyColabApiProject;

namespace Common.RepositoryCommon
{
    public interface IPersonRepository
    {
        public Task<List<Person>> GetAllPersonsAsync();
    }
}
