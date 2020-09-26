using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericUpdateHandler<TCommand, T> : IRequestHandler<TCommand, GenericUpdateViewModel<T>>
        where TCommand : GenericUpdateCommand<T>
        where T : class, new()
    {
        public Task<GenericUpdateViewModel<T>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() => new GenericUpdateViewModel<T>
            {
                Data = Activator.CreateInstance<T>()
            }, cancellationToken);
        }
    }
}