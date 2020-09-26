using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericGetManyHandler<TQuery, T> : IRequestHandler<TQuery, GenericGetManyViewModel<T>>
        where TQuery : GenericGetManyQuery<T>
        where T : class, new()
    {
        public Task<GenericGetManyViewModel<T>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => new GenericGetManyViewModel<T>
            {
                Page = request.Page, Count = request.Count, Data = new List<T>()
            }, cancellationToken);
        }
    }
}