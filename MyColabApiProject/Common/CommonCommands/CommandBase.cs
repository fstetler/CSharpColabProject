using Common.Result;
using MediatR;

namespace Common.CommonCommands
{
    public class CommandBase<TEntity> : IRequest<Result<TEntity>> where TEntity : class
    {
    }
}
