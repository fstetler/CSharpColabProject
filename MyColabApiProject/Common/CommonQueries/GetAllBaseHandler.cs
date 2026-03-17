using Common.CommonRepository;
using MediatR;

namespace Common.CommonQueries
{
    public class GetAllBaseHandler<TEntity> : IRequestHandler<GetAllBaseQuery<TEntity>, List<TEntity>>
    {
        private readonly IRepository<TEntity> _repository;

        public GetAllBaseHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public Task<List<TEntity>> Handle(GetAllBaseQuery<TEntity> request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetAllAsync().Result);
        }
    }
}
