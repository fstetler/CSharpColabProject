using MediatR;

namespace Common.CommonUpdateCommand
{
    public abstract class UpdateCommandBase<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public Guid Id { get; set; }
        public TEntity Entity { get; set; }

        protected UpdateCommandBase(Guid id, TEntity entity)
        {
            Id = id;
            Entity = entity;
        }
    }
}
