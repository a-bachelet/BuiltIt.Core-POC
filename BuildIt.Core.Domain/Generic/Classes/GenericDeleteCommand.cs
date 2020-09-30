using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericDeleteCommand<T> : IRequest<GenericDeleteViewModel<T>> where T : class, new()
    {
        [FromRoute(Name = "guid")] public Guid Guid { get; set; }
    }
}