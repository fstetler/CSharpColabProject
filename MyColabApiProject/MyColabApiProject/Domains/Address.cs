using System.Diagnostics.CodeAnalysis;

namespace MyColabApiProject
{
    public class Address
    {
        public Guid Id { get; set; }
        public required string StreetName { get; set; }
        public required string StreetNumber { get; set; }

        public required string PostalCode { get; set; }
        public required string City { get; set; }

        [SetsRequiredMembers]
        public Address()
        {
            StreetName = string.Empty; 
            StreetNumber = string.Empty; 
            PostalCode = string.Empty; 
            City = string.Empty;
        }
    }
}
