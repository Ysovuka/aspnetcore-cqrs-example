using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.CQRS
{
    public interface IQueryProcessor
    {
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
}
