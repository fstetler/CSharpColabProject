using Riok.Mapperly.Abstractions;
using MyColabApiProject.Domains;

namespace MyColabApiProject.Mappers
{
    [Mapper]
    public static partial class PersonMapper
    {
        public static partial PersonDto Map(Person person);
        public static partial List<PersonDto> Map(IEnumerable<Person> persons);
    }
}
