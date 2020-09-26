using System;
using BuildIt.Core.Domain.Generic.Classes;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using PluralizeService.Core;

namespace BuildIt.Core.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GenericControllerAttribute : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.GetGenericTypeDefinition() != typeof(GenericController<>)) return;
            var entityType = controller.ControllerType.GenericTypeArguments[0];
            controller.ControllerName = PluralizationProvider.Pluralize(entityType.Name);
        }
    }
}