using System;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericGetOneViewModel<T> where T : class, new()
    {
        public T Data { get; set; }
    }
}