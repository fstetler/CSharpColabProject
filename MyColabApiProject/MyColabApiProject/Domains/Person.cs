namespace MyColabApiProject
{
    public class Person
    {
        public Guid Id { get; set; }
        public required string Name { get; set; } = string.Empty;

        public Person()
        {
        }
    }
}
