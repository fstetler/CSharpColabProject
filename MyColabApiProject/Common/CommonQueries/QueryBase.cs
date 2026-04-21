using Common.Result;
using MediatR;

namespace Common.CommonQueries
{
    public class QueryBase<TResult> : IRequest<Result<TResult>>
    {
    }
}
