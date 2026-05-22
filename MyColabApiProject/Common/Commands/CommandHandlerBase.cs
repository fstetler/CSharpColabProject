using Common.Result;
using MediatR;

namespace Common.CommonCommands 
{
    public abstract class CommandHandlerBase<TCommand, TEntity> : IRequestHandler<TCommand, Result<TEntity>> 
        where TCommand : CommandBase<TEntity>
        where TEntity : class
    {
        public abstract Task<Result<TEntity>> Handle(TCommand request, CancellationToken cancellationToken);

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
