using MediatR;

namespace Common.CommonCommands
{
    public class CreateBaseCommand<TResult> : IRequest<TResult>
    {
        public required string Name { get; set; }

        public CreateBaseCommand(string name)
        {
            Name = name;
        }
    }
}
