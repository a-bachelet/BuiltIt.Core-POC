using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericGetOneHandler<TQuery, T> : IRequestHandler<TQuery, GenericGetOneViewModel<T>>
        where TQuery : GenericGetOneQuery<T>
        where T : class, new()
    {
        public Task<GenericGetOneViewModel<T>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => new GenericGetOneViewModel<T>
            {
                Data = Activator.CreateInstance<T>()
            }, cancellationToken);
        }
    }
}