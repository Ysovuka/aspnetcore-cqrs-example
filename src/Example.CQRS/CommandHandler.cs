﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.CQRS
{
    public abstract class CommandHandler<TCommand, TContext> : ICommandHandler<TCommand>
        where TContext : class
        where TCommand : ICommand
    {
        protected readonly TContext _dbContext;
        public CommandHandler(TContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("DbContext", "DbContext cannot be null.");
        }

        public void Dispose()
        {
            (_dbContext as IDisposable)?.Dispose();

            GC.SuppressFinalize(this);
        }

        public abstract Task ExecuteAsync(TCommand command);
    }
}
