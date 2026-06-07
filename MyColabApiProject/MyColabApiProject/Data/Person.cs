namespace MyColabApiProject.Data
{
    public class Person
    {
        public Guid Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public Address Address { get; set; }
        public Person()
        {
        }
    }
}
