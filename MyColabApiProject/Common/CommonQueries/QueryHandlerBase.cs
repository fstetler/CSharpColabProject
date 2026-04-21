using Common.Result;
using MediatR;

namespace Common.CommonQueries
{
    public abstract class QueryHandlerBase<TQuery, TResult> : IRequestHandler<TQuery, Result<TResult>> 
        where TQuery : QueryBase<TResult>
    {
        public abstract Task<Result<TResult>> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
