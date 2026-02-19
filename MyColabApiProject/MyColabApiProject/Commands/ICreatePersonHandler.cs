namespace MyColabApiProject.Commands
{
    public interface ICreatePersonHandler
    {
        Task<Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken);
    }
}