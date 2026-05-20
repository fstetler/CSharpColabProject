namespace MyColabApiProject
{
    public class Address
    {
        public Guid Id { get; set; }
        public required string StreetName { get; set; } = string.Empty;
        public required string StreetNumber { get; set; } = string.Empty;

        public required string PostalCode { get; set; } = string.Empty;
        public required string City { get; set; } = string.Empty;

        public Address()
        {
        }
    }
}
