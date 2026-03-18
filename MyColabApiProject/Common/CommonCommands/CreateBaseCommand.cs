using MediatR;

namespace Common.CommonCommands
{
    public class CreateBaseCommand<TEntity> : IRequest<TEntity>
    {

        public TEntity Entity { get; set; }

        public CreateBaseCommand(TEntity entity)
        {
            Entity = entity;
        }
    }
}
