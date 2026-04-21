using MediatR;
using Common.Result;

namespace Common.CommonCommands 
{
    public abstract class CommandHandlerBase<TCommand, TEntity> : IRequestHandler<TCommand, Result<TEntity>> 
        where TCommand : CommandBase<TEntity>
        where TEntity : class
    {
        public abstract Task<Result<TEntity>> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
