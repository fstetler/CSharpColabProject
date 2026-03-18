using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Common.CommonCommands
{
    public class CreateBaseCommand<TResult> : IRequest<TResult>
    {

        public string Name { get; set; }

        public CreateBaseCommand(string name)
        {
            Name = name;
        }
    }
}
