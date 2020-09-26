using System;
using System.Threading.Tasks;
using BuildIt.Core.Domain.Generic.Classes;
using Microsoft.AspNetCore.Mvc;

namespace BuildIt.Core.Domain.Generic.Interfaces
{
    public interface IGenericController<T> where T : class, new()
    {
        Task<ActionResult<GenericGetManyViewModel<T>>> GetAll(GenericGetManyQuery<T> request);

        Task<ActionResult<GenericGetOneViewModel<T>>> GetOneById(GenericGetOneQuery<T> request);

        Task<ActionResult<GenericCreateViewModel<T>>> Create(GenericCreateCommand<T> request);

        Task<ActionResult<GenericUpdateViewModel<T>>> Update(GenericUpdateCommand<T> request);

        Task<ActionResult<GenericDeleteViewModel<T>>> Delete(GenericDeleteCommand<T> request);
    }
}