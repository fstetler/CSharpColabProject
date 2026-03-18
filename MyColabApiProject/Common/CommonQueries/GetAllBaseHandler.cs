using Common.CommonRepository;
using MediatR;

namespace Common.CommonQueries
{
    public class GetAllBaseHandler<TQuery, TEntity> : IRequestHandler<TQuery, List<TEntity>>
        where TQuery : GetAllBaseQuery<TEntity>
    {
        private readonly IRepository<TEntity> _repository;

        public GetAllBaseHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public Task<List<TEntity>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetAllAsync().Result);
        }
    }
}
