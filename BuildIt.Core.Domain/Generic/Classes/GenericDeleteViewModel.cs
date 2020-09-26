using System;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericDeleteViewModel<T> where T : class, new()
    {
        public T Data  { get; set; }
    }
}