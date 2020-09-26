using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericCreateHandler<TCommand, T> : IRequestHandler<TCommand, GenericCreateViewModel<T>>
        where TCommand : GenericCreateCommand<T>
        where T : class, new()
    {
        public Task<GenericCreateViewModel<T>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() => new GenericCreateViewModel<T>
            {
                Data = Activator.CreateInstance<T>()
            }, cancellationToken);
        }
    }
}