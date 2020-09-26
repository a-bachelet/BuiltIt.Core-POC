using System;
using System.Threading.Tasks;
using Autofac;
using BuildIt.Core.Domain.Attributes;
using BuildIt.Core.Domain.Generic.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuildIt.Core.Domain.Generic.Classes
{
    [GenericController]
    public class GenericController<T> : Controller, IGenericController<T> where T : class, new()
    {
        private readonly IMediator _mediator;

        public GenericController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/[controller]")]
        public async Task<ActionResult<GenericGetManyViewModel<T>>> GetAll([FromQuery] GenericGetManyQuery<T> request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("/[controller]/{guid}")]
        public async Task<ActionResult<GenericGetOneViewModel<T>>> GetOneById([FromRoute] GenericGetOneQuery<T> request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("/[controller]")]
        public async Task<ActionResult<GenericCreateViewModel<T>>> Create([FromBody] GenericCreateCommand<T> request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("/[controller]/{guid}")]
        public async Task<ActionResult<GenericUpdateViewModel<T>>> Update([FromRoute, FromBody] GenericUpdateCommand<T> request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("/[controller]/{guid}")]
        public async Task<ActionResult<GenericDeleteViewModel<T>>> Delete([FromRoute] GenericDeleteCommand<T> request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}