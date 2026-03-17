using MediatR;

namespace Common.CommonQueries
{
    public class GetAllBaseQuery<TEntity> : IRequest<List<TEntity>>
    {
    }
}
