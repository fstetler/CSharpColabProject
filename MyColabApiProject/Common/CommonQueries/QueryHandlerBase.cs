using Common.Result;
using MediatR;

namespace Common.CommonQueries
{
    public abstract class QueryHandlerBase<TQuery, TEntity> : IRequestHandler<TQuery, Result<TEntity>> 
        where TQuery : QueryBase<TEntity>
    {
        public abstract Task<Result<TEntity>> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
