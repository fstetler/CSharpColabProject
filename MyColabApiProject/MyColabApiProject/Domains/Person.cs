using System.Diagnostics.CodeAnalysis;

namespace MyColabApiProject
{
    public class Person
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public required string Address { get; set; }

        [SetsRequiredMembers]
        public Person()
        {
            Name = string.Empty;
            Address = string.Empty;
        }
    }
}
