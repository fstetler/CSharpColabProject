using MediatR;

namespace MyColabApiProject.Queries
{
    public class GetPersonByIdQuery : IRequest<Person>
    {

        public Guid Id { get; set; }

        public GetPersonByIdQuery(Guid id) 
        {
            this.Id = id;
        }
    }
}
