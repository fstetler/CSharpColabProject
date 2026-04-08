using MediatR;

namespace Common.CommonQueries
{
    public class QueryBase<TEntity> : IRequest<List<TEntity>>
    {
    }
}
