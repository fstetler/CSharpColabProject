namespace MyColabApiProject.Domains
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public required string StreetName { get; set; }
        public required string StreetNumber { get; set; }

        public required string PostalCode { get; set; }
        public required string City { get; set; }
    }
}
