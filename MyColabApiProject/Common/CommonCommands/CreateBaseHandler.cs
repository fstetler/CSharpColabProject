using Common.CommonRepository;
using MediatR;

namespace Common.CommonCommands
{
    public class CreateBaseHandler<TCommand, TEntity> : IRequestHandler<TCommand, TEntity> 
        where TCommand : CreateBaseCommand<TEntity>
        where TEntity : new()
    {
        private readonly IRepository<TEntity> _repository;

        public CreateBaseHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> Handle(TCommand request, CancellationToken ct)
        {
            TEntity entity = CreateEntity(request);
            return await _repository.AddAsync(entity);
        }

        protected virtual TEntity CreateEntity(TCommand request)
        {
            return new TEntity();
        }
    }
}
