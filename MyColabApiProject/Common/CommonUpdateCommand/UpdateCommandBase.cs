using MediatR;

namespace Common.CommonUpdateCommand
{
    public abstract class UpdateCommandBase<TEntity> : IRequest<TEntity?> where TEntity : class
    {
    }
}
