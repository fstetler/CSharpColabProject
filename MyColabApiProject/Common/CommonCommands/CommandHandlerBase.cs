using MediatR;
using Common.Result;

namespace Common.CommonCommands
{
    public abstract class CommandHandlerBase<TCommand, TEntity> : IRequestHandler<TCommand, ResultGeneric<TEntity>> 
        where TCommand : CommandBase<ResultGeneric<TEntity>>
        where TEntity : class
    {
        public abstract Task<ResultGeneric<TEntity>> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
