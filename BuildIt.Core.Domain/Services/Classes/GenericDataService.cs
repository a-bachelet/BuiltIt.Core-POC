using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using BuildIt.Core.Domain.FeatureProviders;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace BuildIt.Core.Domain.Services.Classes
{
    public static class GenericDataService
    {
        private static Assembly Assembly { get; set; }

        public static Assembly GetGenericAssembly()
        {
            if (Assembly != null) return Assembly;

            var remoteCode = new HttpClient()
                .GetStringAsync(
                    "https://gist.githubusercontent.com/a-bachelet/02717bc91d66cbf7a7864a5c8d0f62d5/raw/2949868d18221b5e5b7c2c0defd8091ee9287aa0/types.txt"
                )
                .GetAwaiter()
                .GetResult();

            if (remoteCode == null) return null;

            var compilation = CSharpCompilation.Create("DynamicAssembly",
                new[] {CSharpSyntaxTree.ParseText(remoteCode)},
                new[]
                {
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(GenericControllerFeatureProvider).Assembly.Location)
                },
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using var ms = new MemoryStream();

            var emitResult = compilation.Emit(ms);
            
            if (!emitResult.Success)
            {
                // handle, log errors etc
                Debug.WriteLine("Compilation failed!");
                return null;
            }

            ms.Seek(0, SeekOrigin.Begin);

            Assembly = Assembly.Load(ms.ToArray());

            return Assembly;
        }
    }
}