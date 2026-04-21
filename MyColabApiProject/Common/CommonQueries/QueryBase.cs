using Common.Result;
using MediatR;

namespace Common.CommonQueries
{
    public class QueryBase<TEntity> : IRequest<Result<TEntity>>
    {
    }
}
