using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericGetManyQuery<T> : IRequest<GenericGetManyViewModel<T>> where T : class, new()
    {
        [FromQuery(Name = "page")] public int Page { get; set; }

        [FromQuery(Name = "count")] public int Count { get; set; }
    }
}