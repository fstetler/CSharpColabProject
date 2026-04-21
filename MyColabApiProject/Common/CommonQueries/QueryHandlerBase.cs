using Common.Result;
using MediatR;

namespace Common.CommonQueries
{
    public abstract class QueryHandlerBase<TQuery, TResult> : IRequestHandler<TQuery, ResultGeneric<TResult>> 
        where TQuery : QueryBase<ResultGeneric<TResult>>
    {

        public abstract Task<ResultGeneric<TResult>> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
