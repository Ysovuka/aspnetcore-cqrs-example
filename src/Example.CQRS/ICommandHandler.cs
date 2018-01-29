using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.CQRS
{
    public interface ICommandHandler<TCommand> :
        IDisposable
        where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}
