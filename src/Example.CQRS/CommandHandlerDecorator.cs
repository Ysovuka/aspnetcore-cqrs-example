﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.CQRS
{
    public abstract class CommandHandlerDecorator<TContext, TCommand> :
        ICommandHandler<TCommand>
        where TContext : class
        where TCommand : ICommand
    {
        protected readonly TContext _dbContext;
        protected readonly ICommandHandler<TCommand> _decorated;
        public CommandHandlerDecorator(TContext dbContext, ICommandHandler<TCommand> commandHandler)
        {
            _dbContext = dbContext;
            _decorated = commandHandler;
        }

        public void Dispose()
        {
            (_dbContext as IDisposable)?.Dispose();

            GC.SuppressFinalize(this);
        }

        public abstract Task ExecuteAsync(TCommand command);
    }
}
