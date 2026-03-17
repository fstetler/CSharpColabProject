using Common.CommonRepository;
using MediatR;

namespace Common.CommonCommands
{
    public class CreateBaseHandler<TEntity> : IRequestHandler<CreateBaseCommand<TEntity>, TEntity> where TEntity : new()
    {
        private readonly IRepository<TEntity> _repository;

        public CreateBaseHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> Handle(CreateBaseCommand<TEntity> request, CancellationToken ct)
        {
            TEntity entity = CreateEntity(request);
            return await _repository.AddAsync(entity);
        }

        protected virtual TEntity CreateEntity(CreateBaseCommand<TEntity> request)
        {
            return new TEntity();
        }
    }
}
