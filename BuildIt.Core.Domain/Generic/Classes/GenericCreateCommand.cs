using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericCreateCommand<T> : IRequest<GenericCreateViewModel<T>> where T : class, new()
    {
        [FromBody] public T Data { get; set; }
    }
}