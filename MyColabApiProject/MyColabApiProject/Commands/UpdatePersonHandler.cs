using Common.CommonCommands;
using MyColabApiProject.Domains;
using MyColabApiProject.Mappers;
using MyColabApiProject.Repository;

namespace MyColabApiProject.Commands
{
    public class UpdatePersonHandler : CommandHandlerBase<UpdatePersonCommand, PersonDto>
    {

        private readonly IPersonRepository _repository;

        public UpdatePersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public override async Task<PersonDto?> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            Person? person = await _repository.GetByIdAsync(request.Id);
            if (person is null)
            {
                return null;
            }

            person.Name = request.Name;
            _repository.Update(person);
            await _repository.SaveChangesAsync();
            return PersonMapper.Map(person);
        }
    }
}
