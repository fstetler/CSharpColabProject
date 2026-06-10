using MyColabApiProject.Data;

namespace MyColabApiProject.Domains
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Address Address { get; set; }

    }
}
