using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.CQRS
{
    public interface IQueryHandler<TQuery, TResult> :
        IDisposable
        where TQuery : IQuery<TResult>
    {
        Task<TResult> ExecuteAsync(TQuery query);
    }
}
