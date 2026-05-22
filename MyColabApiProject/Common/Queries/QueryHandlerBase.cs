using Common.Result;
using MediatR;

namespace Common.CommonQueries
{
    public abstract class QueryHandlerBase<TQuery, TEntity> : IRequestHandler<TQuery, Result<TEntity>> 
        where TQuery : QueryBase<TEntity>
    {
        public abstract Task<Result<TEntity>> Handle(TQuery request, CancellationToken cancellationToken);

        public Result<TEntity> Ok(TEntity value)
        {
            return Result<TEntity>.Ok(value);
        }

        public Result<TEntity> BadRequest(string error)
        {
            return Result<TEntity>.BadRequest(error);
        }

        public Result<TEntity> Unauthorized(string error)
        {
            return Result<TEntity>.Unauthorized(error);
        }

        public Result<TEntity> Forbidden(string error)
        {
            return Result<TEntity>.Forbidden(error);
        }

        public Result<TEntity> NotFound(string error)
        {
            return Result<TEntity>.NotFound(error);
        }
    }
}
