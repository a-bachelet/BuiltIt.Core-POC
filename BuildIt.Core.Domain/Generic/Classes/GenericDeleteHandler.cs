using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericDeleteHandler<TCommand, T> : IRequestHandler<TCommand, GenericDeleteViewModel<T>>
        where TCommand : GenericDeleteCommand<T>
        where T : class, new()
    {
        public Task<GenericDeleteViewModel<T>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() => new GenericDeleteViewModel<T>
            {
                Data = Activator.CreateInstance<T>()
            }, cancellationToken);
        }
    }
}