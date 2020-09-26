using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericUpdateCommand<T> : IRequest<GenericUpdateViewModel<T>> where T : class, new()
    {
        [FromRoute(Name = "guid")]
        public Guid Guid { get; set; }
        
        [FromBody]
        public T Data { get; set; }
    }
}