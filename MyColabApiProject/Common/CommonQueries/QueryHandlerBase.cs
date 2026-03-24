using MediatR;

namespace Common.CommonQueries
{
    public abstract class QueryHandlerBase<TQuery, TEntity> : IRequestHandler<TQuery, List<TEntity>>
        where TQuery : QueryBase<TEntity>
    {

        public abstract Task<List<TEntity>> Handle(TQuery request, CancellationToken cancellationToken);

    }
}
