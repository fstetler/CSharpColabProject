using MediatR;

namespace Common.CommonUpdateCommand
{
    public abstract class UpdateCommandHandlerBase<TCommand, TEntity> : IRequestHandler<TCommand, TEntity?>
        where TCommand : UpdateCommandBase<TEntity>
        where TEntity : class
    {
        public abstract Task<TEntity?> Handle(TCommand request, CancellationToken cancellationToken);
    }
}