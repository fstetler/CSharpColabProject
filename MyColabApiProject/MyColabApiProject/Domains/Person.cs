using System.Diagnostics.CodeAnalysis;

namespace MyColabApiProject
{
    public class Person
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        [SetsRequiredMembers]
        public Person()
        {
            Name = string.Empty;
        }
    }
}
