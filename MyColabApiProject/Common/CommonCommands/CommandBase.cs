using MediatR;

namespace Common.CommonCommands
{
    public class CommandBase<TEntity> : IRequest<TEntity>
    {
    }
}
