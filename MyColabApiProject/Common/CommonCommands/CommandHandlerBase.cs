using MediatR;

namespace Common.CommonCommands
{
    public abstract class CommandHandlerBase<TCommand, TEntity> : IRequestHandler<TCommand, TEntity> 
        where TCommand : CommandBase<TEntity>
        where TEntity : class
    {
        public abstract Task<TEntity> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
