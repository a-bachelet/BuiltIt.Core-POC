using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BuildIt.Core.Domain.Generic.Classes;
using BuildIt.Core.Domain.Services.Classes;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace BuildIt.Core.Domain.FeatureProviders
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var assembly = GenericDataService.GetGenericAssembly();

            var candidates = assembly.GetExportedTypes().Where(x => !x.IsAbstract);

            foreach (var candidate in candidates)
                feature.Controllers.Add(
                    typeof(GenericController<>).MakeGenericType(candidate).GetTypeInfo()
                );
        }
    }
}