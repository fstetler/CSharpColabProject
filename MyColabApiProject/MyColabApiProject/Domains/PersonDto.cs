using System.Text.Json.Serialization;

namespace MyColabApiProject.Domains
{
    public class PersonDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public required String Name { get; set; }
    }
}
